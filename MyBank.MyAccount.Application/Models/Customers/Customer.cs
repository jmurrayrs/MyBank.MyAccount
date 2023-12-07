
namespace MyBank.MyAccount.Application.Models.Customers
{
    public sealed class Customer
    {
        public string CPF { get; set; } = default!;
        public Document Document { get; set; } = default!;
        public DateTime Birthday { get; set; } = default!;

    }
}