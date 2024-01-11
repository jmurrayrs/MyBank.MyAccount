using FluentValidation.Results;
using MyBank.MyAccount.Crosscutting.Validators.Domain;
using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Domain.Interfaces.Aggregates;
using MyBank.MyAccount.Domain.Shared;

namespace MyBank.MyAccount.Domain.Aggregates.Accounts
{
    public class Account
        : EntityBase<Guid>, IAggregate
    {
        public Customer Customer { get; private set; } = default!;
        public Guid CustomerId { get; private set; } = default!;
        public decimal Balance { get; private set; } = default!;

        public Account()
        { }

        public Account(
            Customer customer,
            decimal balance
        )
        {
            Customer = customer;
            Balance = balance;
        }












    }
}