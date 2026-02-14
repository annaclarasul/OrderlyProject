using Orderly.Domain.Models;

namespace Orderly.Domain.Interfaces.Services;

public interface IClienteAppService
{
    Task<Cliente> CreateAsync(Cliente request);
    Task<IEnumerable<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(Guid id);
    Task<Cliente> UpdateAsync(Guid id, Cliente request);
    Task DeleteAsync(Guid id);
}


