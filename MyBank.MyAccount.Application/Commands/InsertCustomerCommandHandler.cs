using MediatR;
using MyBank.MyAccount.Domain.DomainEvents;
using MyBank.MyAccount.Domain.Interfaces.Repository;

namespace MyBank.MyAccount.Application.Commands;

public class InsertCustomerCommandHandler
    : IRequestHandler<InsertCustomerCommand, Guid>
{
    private readonly IMediator _mediator;
    private readonly ICustomerRepository _customerRepository;
    public InsertCustomerCommandHandler(
        IMediator mediator,
        ICustomerRepository customerRepository
    )
    {
        _mediator = mediator;
        _customerRepository = customerRepository;
    }
    public async Task<Guid> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {


        // Disparar o evento de domínio usando o Mediator
        await _mediator.Publish(new CustomerInsertedEvent(customerId), cancellationToken);

        return customerId;
    }
}
