using Orderly.Main.Models;

namespace Orderly.Main.Interfaces.Services;

public interface IPedidoService
{
    Task<Pedido> CriarPedidoAsync(int clienteId);
    Task AdicionarItemAsync(int pedidoId, int produtoId, int quantidade);
    Task MarcarComoPagoAsync(int pedidoId);
    Task CancelarPedidoAsync(int pedidoId);
    Task<Pedido?> ObterPedidoAsync(int id);
}
