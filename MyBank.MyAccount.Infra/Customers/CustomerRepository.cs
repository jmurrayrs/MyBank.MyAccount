using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Domain.Interfaces.Repository;
using MyBank.MyAccount.Infra.Context;

namespace MyBank.MyAccount.Infra.Customers;

public class CustomerRepository
    : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task InsertCustomerAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
    }
}
