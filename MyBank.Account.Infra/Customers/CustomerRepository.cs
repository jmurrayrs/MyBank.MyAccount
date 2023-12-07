using MyBank.Account.Domain.Aggregates.Costumers;
using MyBank.Account.Domain.Interfaces.Repository;
using MyBank.Account.Infra.Context;

namespace MyBank.Account.Infra.Customers;

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
