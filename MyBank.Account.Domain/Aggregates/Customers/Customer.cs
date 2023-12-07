using MyBank.Account.Domain.Shared;
using MyBank.Account.Domain.ValueObjects;

namespace MyBank.Account.Domain.Aggregates.Costumers
{
    public sealed class Customer : EntityBase<Guid>
    {
        public Identification Identification { get; private set; } = default!;
        public Document Document { get; private set; } = default!;
        public DateTime Birthday { get; private set; } = default!;

    }
}