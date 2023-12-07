namespace MyBank.Account.Domain.Interfaces.Repository;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Rollback();
}
