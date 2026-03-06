using System.Linq.Expressions;

namespace Orderly.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(Guid id);

    Task<T?> GetByIdAsync(Guid id);

    Task<IEnumerable<T>> GetAllAsync();
}