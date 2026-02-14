using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ClienteRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddAsync(Cliente cliente)
    {
        var persistencia = _mapper.Map<ClientePersistencia>(cliente);

        await _context.Clientes.AddAsync(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        var persistencia = _mapper.Map<ClientePersistencia>(cliente);

        _context.Clientes.Update(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        var persistencia = await _context.Clientes
            .Include(c => c.Pedidos)
            .FirstOrDefaultAsync(c => c.Id == id);

        return persistencia == null
            ? null
            : _mapper.Map<Cliente>(persistencia);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        var lista = await _context.Clientes
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<Cliente>>(lista);
    }
}




