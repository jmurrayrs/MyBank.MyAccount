using MyBank.Account.Domain.Aggregates.Costumers;

namespace MyBank.Account.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task InsertCustomerAsync(Customer customer);
    }
}