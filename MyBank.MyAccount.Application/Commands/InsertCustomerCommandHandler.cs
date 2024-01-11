using AutoMapper;
using HaidaiTech.Notificator.Interfaces;
using HaidaiTech.Notificator.NotificationContextMessages;
using MediatR;
using MyBank.MyAccount.Application.Models.Customers;
using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Domain.DomainEvents;
using MyBank.MyAccount.Domain.Interfaces.Repository;

namespace MyBank.MyAccount.Application.Commands;

public class InsertCustomerCommandHandler
    : IRequestHandler<InsertCustomerCommand, Guid>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationContext<NotificationContextMessage> _notificationContext;

    public InsertCustomerCommandHandler(
        IMediator mediator,
        IRepository<Customer> customerRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        INotificationContext<NotificationContextMessage> notificationContext
    )
    {
        _mediator = mediator;
        _customerRepository = customerRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }
    public async Task<Guid> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {

        var customer = _mapper.Map<CustomerModel, Customer>(request.Customer);

        await _customerRepository.AddAsync(customer);

        try
        {
            await _unitOfWork.CommitAsync();
            await _mediator.Publish(new CustomerInsertedEvent(customer.Id), cancellationToken);
            return customer.Id;
        }
        catch
        {
            await _notificationContext.AddNotificationAsync(
                new NotificationContextMessage("The Customer can't be inserted")
            );

            _unitOfWork.Rollback();
        }

        return default;

    }
}
