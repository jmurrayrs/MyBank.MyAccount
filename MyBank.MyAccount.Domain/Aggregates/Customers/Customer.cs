using MyBank.MyAccount.Domain.Shared;
using MyBank.MyAccount.Domain.ValueObjects;

namespace MyBank.MyAccount.Domain.Aggregates.Costumers
{
    public sealed class Customer : EntityBase<Guid>
    {
        public Identification Identification { get; private set; } = default!;
        public Document Document { get; private set; } = default!;
        public DateTime Birthday { get; private set; } = default!;

    }
}