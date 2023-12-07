using MediatR;

namespace MyBank.Account.Domain.DomainEvents
{
    public class CustomerInsertedEvent
        : INotification
    {
        public Guid CustomerId { get; }

        public CustomerInsertedEvent(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}