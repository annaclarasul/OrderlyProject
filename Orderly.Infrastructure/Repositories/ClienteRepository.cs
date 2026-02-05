using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;

namespace Orderly.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
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
        return await _context.Clientes
            .Include(c => c.Pedidos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .AsNoTracking()
            .ToListAsync();
    }
}




