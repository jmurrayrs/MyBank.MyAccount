using Microsoft.EntityFrameworkCore.Storage;
using MyBank.MyAccount.Domain.Aggregates.Accounts;
using MyBank.MyAccount.Domain.Aggregates.Costumers;
using MyBank.MyAccount.Domain.Interfaces.Repository;
using MyBank.MyAccount.Infra.Context;
using MyBank.MyAccount.Infra.Repository;

namespace MyBank.MyAccount.Infra.UoW;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _dbContext;
    public IRepository<Customer> CustomerRepository => new GenericRepository<Customer>(_dbContext);
    public IRepository<Account> AccountRepository => new GenericRepository<Account>(_dbContext);
    private readonly IDbContextTransaction _transaction;


    public UnitOfWork(
        AppDbContext dbContext
    )
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