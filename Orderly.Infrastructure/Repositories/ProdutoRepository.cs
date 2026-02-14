using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Models;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProdutoRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddAsync(Produto produto)
    {
        var persistencia = _mapper.Map<ProdutoPersistencia>(produto);
        await _context.Produtos.AddAsync(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        var persistencia = _mapper.Map<ProdutoPersistencia>(produto);
        _context.Produtos.Update(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        var persistencia = await _context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id);

        return persistencia == null
            ? null
            : _mapper.Map<Produto>(persistencia);
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        var lista = await _context.Produtos
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<Produto>>(lista);
    }
}
