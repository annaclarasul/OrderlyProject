using Orderly.Domain.Models;

namespace Orderly.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    Task AddAsync(Cliente cliente);
    Task UpdateAsync(Cliente cliente);
    Task DeleteAsync(Guid id);

    Task<Cliente?> GetByIdAsync(Guid id);
    Task<IEnumerable<Cliente>> GetAllAsync();
}


