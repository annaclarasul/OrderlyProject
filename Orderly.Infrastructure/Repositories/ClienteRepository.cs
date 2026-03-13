using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;

public class ClienteRepository
    : RepositoryBase<Cliente>, IClienteRepository
{
    public ClienteRepository(AppDbContext context)
        : base(context)
    {
    }

    public Task<Cliente?> ObterCliente(Guid id)
    {
        return GetByIdAsync(id);
    }

    public Task<IEnumerable<Cliente>> ListarClientes()
    {
        return GetAllAsync();
    }
}
