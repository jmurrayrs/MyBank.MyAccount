
using MyBank.Account.Application.Models.Customers;

namespace MyBank.Account.Application.Models.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; } = default!;
        public decimal Balance { get; set; }
    }
}