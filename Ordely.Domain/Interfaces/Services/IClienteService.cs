using Orderly.Main.Models;

namespace Orderly.Main.Interfaces.Services;

public interface IClienteService
{
    Task<Cliente> CriarClienteAsync(string nome, string email);
    Task AtualizarClienteAsync(int id, string nome, string email);
    Task<Cliente?> ObterClienteAsync(int id);
    Task<IEnumerable<Cliente>> ListarClientesAsync();
    Task RemoverClienteAsync(int id);
}

