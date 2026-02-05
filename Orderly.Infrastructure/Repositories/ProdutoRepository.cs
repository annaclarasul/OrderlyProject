using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;

namespace Orderly.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        return await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        return await _context.Produtos
            .AsNoTracking()
            .ToListAsync();
    }
}

