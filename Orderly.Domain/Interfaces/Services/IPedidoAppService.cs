using Orderly.Domain.Models;
using Orderly.Domain.Enums;

namespace Orderly.Domain.Interfaces.Services;
public interface IPedidoAppService
{
    Task<Pedido> CreateAsync(Pedido request);
    Task<IEnumerable<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(Guid id);
    Task AtualizarStatusAsync(Guid pedidoId, StatusPedido novoStatus);
}


