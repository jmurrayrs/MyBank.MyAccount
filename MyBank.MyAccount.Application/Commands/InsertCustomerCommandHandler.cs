using AutoMapper;
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
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public InsertCustomerCommandHandler(
        IMediator mediator,
        ICustomerRepository customerRepository,
        IMapper mapper
    )
    {
        _mediator = mediator;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {

        var customer = _mapper.Map<CustomerModel, Customer>(request.Customer);

        await _customerRepository.InsertCustomerAsync(customer);

        await _mediator.Publish(new CustomerInsertedEvent(customer.Id), cancellationToken);

        return customer.Id;
    }
}
