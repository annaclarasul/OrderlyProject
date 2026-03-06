using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Models;

public class PedidoRepository
    : RepositoryBase<Pedido, PedidoPersistencia>,
      IPedidoRepository
{
    public PedidoRepository(AppDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }

    async Task<Pedido?> IPedidoRepository.GetByIdAsync(Guid id)
    {
        var persistencia = await _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .FirstOrDefaultAsync(p => p.Id == id);

        return persistencia == null
            ? null
            : _mapper.Map<Pedido>(persistencia);
    }
}

