
using MyBank.MyAccount.Application.Models.Customers;

namespace MyBank.MyAccount.Application.Models.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; } = default!;
        public decimal Balance { get; set; }
    }
}