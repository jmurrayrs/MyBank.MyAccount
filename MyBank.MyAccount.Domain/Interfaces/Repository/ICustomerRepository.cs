using MyBank.MyAccount.Domain.Aggregates.Costumers;

namespace MyBank.MyAccount.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task InsertCustomerAsync(Customer customer);
    }
}