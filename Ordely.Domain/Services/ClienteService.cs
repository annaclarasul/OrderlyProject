using Orderly.Main.Interfaces.Repositories;
using Orderly.Main.Interfaces.Services;
using Orderly.Main.Models;
using Orderly.Main.ValueObjects;

namespace Orderly.Main.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repo;

    public ClienteService(IClienteRepository repo)
    {
        _repo = repo;
    }

    public async Task<Cliente> CriarClienteAsync(string nome, string email)
    {
        var cliente = new Cliente(nome, new Email(email));
        await _repo.AdicionarAsync(cliente);
        return cliente;
    }

    public async Task AtualizarClienteAsync(int id, string nome, string email)
    {
        var cliente = await _repo.ObterPorIdAsync(id)
            ?? throw new Exception("Cliente não encontrado");

        cliente.AtualizarNome(nome);
        cliente.AtualizarEmail(new Email(email));

        await _repo.AtualizarAsync(cliente);
    }

    public Task<Cliente?> ObterClienteAsync(int id)
        => _repo.ObterPorIdAsync(id);

    public Task<IEnumerable<Cliente>> ListarClientesAsync()
        => _repo.ListarAsync();

    public Task RemoverClienteAsync(int id)
        => _repo.RemoverAsync(id);
}

