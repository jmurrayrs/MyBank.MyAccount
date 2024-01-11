using MyBank.MyAccount.Crosscutting.Validators.Domain;
using MyBank.MyAccount.Domain.Interfaces.Aggregates;
using MyBank.MyAccount.Domain.Shared;
using MyBank.MyAccount.Domain.ValueObjects;

namespace MyBank.MyAccount.Domain.Aggregates.Costumers
{
    public sealed class Customer
        : EntityBase<Guid>, IAggregate
    {
        private int _age = 0;
        public Identification Identification { get; private set; } = default!;
        public Document Document { get; private set; } = default!;
        public DateTime Birthday { get; private set; } = default!;
        public int Age { get; private set; } = default!;

        public Customer()
        { }

        public Customer(
            Identification identification,
            Document document,
            DateTime birthday
        )
        {
            _age = DateTime.Now.Subtract(Birthday).Days / 365;

            Identification = identification;
            Document = document;
            Birthday = birthday;
            Age = _age;
        }
    }
}