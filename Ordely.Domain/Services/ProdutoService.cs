using Orderly.Main.Interfaces.Repositories;
using Orderly.Main.Interfaces.Services;
using Orderly.Main.Models;

namespace Orderly.Main.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public Task AddAsync(Produto produto)
    {
        throw new NotImplementedException();
    }

    public async Task<Produto> CriarProdutoAsync(
        string nome,
        string descricao,
        decimal preco,
        int estoque)
    {
        var produto = new Produto(nome, descricao, preco, estoque);
        await _repo.AdicionarAsync(produto);
        return produto;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Produto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Produto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Produto>> ListarProdutosAsync()
        => _repo.ListarAsync();

    public Task<Produto?> ObterProdutoAsync(int id)
        => _repo.ObterPorIdAsync(id);

    public Task UpdateAsync(Produto produto)
    {
        throw new NotImplementedException();
    }
}
