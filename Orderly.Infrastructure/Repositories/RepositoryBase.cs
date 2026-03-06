using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Infrastructure.Data;

public class RepositoryBase<TDomain, TPersistencia>
    : IRepository<TDomain>
    where TDomain : class
    where TPersistencia : class
{
    protected readonly AppDbContext _context;
    protected readonly IMapper _mapper;
    protected readonly DbSet<TPersistencia> _dbSet;

    public RepositoryBase(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _dbSet = _context.Set<TPersistencia>();
    }

    public async Task AddAsync(TDomain entity)
    {
        var persistencia = _mapper.Map<TPersistencia>(entity);

        await _dbSet.AddAsync(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TDomain entity)
    {
        var persistencia = _mapper.Map<TPersistencia>(entity);

        _dbSet.Update(persistencia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
            return;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TDomain?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity == null
            ? null
            : _mapper.Map<TDomain>(entity);
    }

    public async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        var list = await _dbSet
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<TDomain>>(list);
    }
}