using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyBank.MyAccount.Domain.Interfaces.Repository;

namespace MyBank.MyAccount.Infra.Repository;
public class GenericRepository<T>
    : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public async Task<IQueryable<T>?> GetAllAsync()
        => await Task.Run(() => _dbSet.AsQueryable()) ?? default;

    public async Task<IQueryable<T>?> GetByConditionAsync(Expression<Func<T, bool>> expression)
        => await Task.Run(() => _dbSet.Where(expression).AsQueryable()) ?? default;

    public async Task<T?> GetByIdAsync(Guid id)    
        => await _dbSet.FindAsync(id) ?? default;    

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);    

    public void Update(T entity)
        => _context.Entry(entity).State = EntityState.Modified;    

    public void Delete(T entity)
        => _dbSet.Remove(entity);    

    public async Task<int> Count() => await _dbSet.CountAsync();

}
