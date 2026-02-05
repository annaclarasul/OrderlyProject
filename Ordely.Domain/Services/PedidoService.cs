using Orderly.Main.Interfaces.Repositories;
using Orderly.Main.Interfaces.Services;
using Orderly.Main.Models;

namespace Orderly.Main.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepo;
    private readonly IProdutoRepository _produtoRepo;

    public PedidoService(
        IPedidoRepository pedidoRepo,
        IProdutoRepository produtoRepo)
    {
        _pedidoRepo = pedidoRepo;
        _produtoRepo = produtoRepo;
    }

    public async Task<Pedido> CriarPedidoAsync(int clienteId)
    {
        var pedido = new Pedido(clienteId);
        await _pedidoRepo.AdicionarAsync(pedido);
        return pedido;
    }

    public async Task AdicionarItemAsync(int pedidoId, int produtoId, int quantidade)
    {
        var pedido = await _pedidoRepo.ObterPorIdAsync(pedidoId)
            ?? throw new Exception("Pedido não encontrado");

        var produto = await _produtoRepo.ObterPorIdAsync(produtoId)
            ?? throw new Exception("Produto não encontrado");

        produto.BaixarEstoque(quantidade);
        pedido.AdicionarItem(produtoId, quantidade, produto.Preco);

        await _pedidoRepo.AtualizarAsync(pedido);
    }

    public async Task MarcarComoPagoAsync(int pedidoId)
    {
        var pedido = await _pedidoRepo.ObterPorIdAsync(pedidoId)
            ?? throw new Exception("Pedido não encontrado");

        pedido.MarcarComoPago();
        await _pedidoRepo.AtualizarAsync(pedido);
    }

    public async Task CancelarPedidoAsync(int pedidoId)
    {
        var pedido = await _pedidoRepo.ObterPorIdAsync(pedidoId)
            ?? throw new Exception("Pedido não encontrado");

        pedido.Cancelar();
        await _pedidoRepo.AtualizarAsync(pedido);
    }

    public Task<Pedido?> ObterPedidoAsync(int id)
        => _pedidoRepo.ObterPorIdAsync(id);
}
