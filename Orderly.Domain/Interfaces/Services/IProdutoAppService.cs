using Orderly.Domain.Models;

namespace Orderly.Domain.Interfaces.Services;

public interface IProdutoAppService
{
    Task<Produto> CreateAsync(Produto request);
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(Guid id);
}



