using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PedidoRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddAsync(Pedido pedido)
    {
        var persistencia = _mapper.Map<PedidoPersistencia>(pedido);

        await _context.Pedidos.AddAsync(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pedido pedido)
    {
        var persistencia = _mapper.Map<PedidoPersistencia>(pedido);

        _context.Pedidos.Update(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task<Pedido?> GetByIdAsync(Guid id)
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

    public async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        var lista = await _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<Pedido>>(lista);
    }
}

