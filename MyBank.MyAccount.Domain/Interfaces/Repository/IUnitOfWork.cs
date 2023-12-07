namespace MyBank.MyAccount.Domain.Interfaces.Repository;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Rollback();
}
