using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;

public class PedidoRepository
    : RepositoryBase<Pedido>, IPedidoRepository
{
    public PedidoRepository(AppDbContext context)
        : base(context)
    {
    }

    public Task<Pedido?> ObterPedido(Guid id)
    {
        return GetByIdAsync(id);
    }

    public Task<IEnumerable<Pedido>> ListarPedidos()
    {
        return GetAllAsync();
    }
}

