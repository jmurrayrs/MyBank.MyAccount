using System.Linq.Expressions;

namespace MyBank.MyAccount.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>?> GetAllAsync();
        Task<IQueryable<T>?> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> Count();
    }
}