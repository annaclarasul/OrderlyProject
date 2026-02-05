using Orderly.Main.Models;

namespace Orderly.Main.Interfaces.Repositories;

public interface IPedidoRepository
{
    Task<Pedido?> ObterPorIdAsync(int id);
    Task<IEnumerable<Pedido>> ListarAsync();
    Task AdicionarAsync(Pedido pedido);
    Task AtualizarAsync(Pedido pedido);
}

