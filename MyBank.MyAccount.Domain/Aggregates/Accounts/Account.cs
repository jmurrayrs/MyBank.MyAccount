using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Domain.Shared;

namespace MyBank.MyAccount.Domain.Aggregates.Accounts
{
    public class Account
        : EntityBase<Guid>
    {
        public Customer Customer { get; private set; } = default!;
        public decimal Balance { get; private set; } = default!;
    }
}