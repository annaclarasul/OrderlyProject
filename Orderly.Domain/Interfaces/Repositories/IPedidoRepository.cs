using Orderly.Domain.Models;

namespace Orderly.Domain.Interfaces.Repositories;

public interface IPedidoRepository
{
    Task AddAsync(Pedido pedido);
    Task UpdateAsync(Pedido pedido);

    Task<Pedido?> GetByIdAsync(Guid id);
    Task<IEnumerable<Pedido>> GetAllAsync();
}


