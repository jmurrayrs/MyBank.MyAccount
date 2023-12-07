
using MyBank.MyAccount.Application.Models.Customers;

namespace MyBank.MyAccount.Application.Models.Accounts
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public CustomerModel Customer { get; set; } = default!;
        public decimal Balance { get; set; }
    }
}