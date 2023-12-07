using MediatR;
using MyBank.Account.Application.Models.Customers;

namespace MyBank.Account.Application.Commands
{
    public class InsertCustomerCommand : IRequest<Guid>
    {
        public Customer Customer { get; set; } = default!;
    }
}