using MediatR;
using MyBank.MyAccount.Application.Models.Customers;

namespace MyBank.MyAccount.Application.Commands;

public class InsertCustomerCommand : IRequest<Guid>
{
    public CustomerModel Customer { get; set; } = default!;
}
