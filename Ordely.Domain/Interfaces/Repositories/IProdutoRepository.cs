using Orderly.Main.Models;

namespace Orderly.Main.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task<Produto?> ObterPorIdAsync(int id);
    Task<IEnumerable<Produto>> ListarAsync();
    Task AdicionarAsync(Produto produto);
    Task AtualizarAsync(Produto produto);
    Task RemoverAsync(int id);
}

