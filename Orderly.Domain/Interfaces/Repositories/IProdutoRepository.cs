using Orderly.Domain.Models;

namespace Orderly.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);

    Task<Produto?> GetByIdAsync(Guid id);
    Task<IEnumerable<Produto>> GetAllAsync();
}


