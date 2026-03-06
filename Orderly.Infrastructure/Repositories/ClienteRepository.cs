using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Repositories;

public class ClienteRepository
    : RepositoryBase<Cliente, ClientePersistencia>,
      IClienteRepository
{
    public ClienteRepository(AppDbContext context, IMapper mapper)
        : base(context, mapper)
    {
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
}
