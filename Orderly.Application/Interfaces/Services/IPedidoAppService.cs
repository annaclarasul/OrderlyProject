using Orderly.Application.DTOs.Pedido;
using Orderly.Domain.Enums;

namespace Orderly.Application.Interfaces.Services;

public interface IPedidoAppService
{
    Task<PedidoResponse> CreateAsync(CreatePedidoRequest request);
    Task<IEnumerable<PedidoResponse>> GetAllAsync();
    Task<PedidoResponse?> GetByIdAsync(Guid id);
    Task AtualizarStatusAsync(Guid pedidoId, StatusPedido novoStatus);
}


