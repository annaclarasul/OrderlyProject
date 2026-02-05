using Orderly.Main.Models;

namespace Orderly.Main.Interfaces.Repositories;

public interface IClienteRepository
{
    Task<Cliente?> ObterPorIdAsync(int id);
    Task<IEnumerable<Cliente>> ListarAsync();
    Task AdicionarAsync(Cliente cliente);
    Task AtualizarAsync(Cliente cliente);
    Task RemoverAsync(int id);
}
