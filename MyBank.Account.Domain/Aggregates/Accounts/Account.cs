using MyBank.Account.Domain.Aggregates.Costumers;
using MyBank.Account.Domain.Shared;

namespace MyBank.Account.Domain.Aggregates.Accounts
{
    public class Account : EntityBase<Guid>
    {
        public Customer Customer { get; private set; } = default!;
        public decimal Balance { get; private set; } = default!;
    }
}