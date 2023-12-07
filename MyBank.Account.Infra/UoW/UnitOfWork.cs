using Microsoft.EntityFrameworkCore.Storage;
using MyBank.Account.Domain.Interfaces.Repository;
using MyBank.Account.Infra.Context;
using MyBank.Account.Infra.Customers;

namespace MyBank.Account.Infra.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private ICustomerRepository _customerRepository = default!;
    public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_dbContext);
    private readonly IDbContextTransaction _transaction;


    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _transaction = _dbContext.Database.BeginTransaction();

    }

    public async Task CommitAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();

            _transaction.Commit();

        }
        catch
        {
            /*foreach (var entry in _dbContext.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }*/

            _transaction.Rollback();
            throw;
        }
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void Dispose()
    {
        _transaction.Dispose();
        _dbContext.Dispose();
    }
}