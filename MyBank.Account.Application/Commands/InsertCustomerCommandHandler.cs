using MediatR;
using MyBank.Account.Domain.DomainEvents;

namespace MyBank.Account.Application.Commands;

public class InsertCustomerCommandHandler
    : IRequestHandler<InsertCustomerCommand, Guid>
{
    private readonly IMediator _mediator;
    public InsertCustomerCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<Guid> Handle(InsertCustomerCommand request, CancellationToken cancellationToken)
    {
        // Lógica de inserção do cliente

        // Configurar o Id (pode ser gerado automaticamente ou configurado de outra forma)
        var customerId = Guid.NewGuid();

        // Disparar o evento de domínio usando o Mediator
        await _mediator.Publish(new CustomerInsertedEvent(customerId), cancellationToken);

        return customerId;
    }
}
