using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;

public class ProdutoRepository
    : RepositoryBase<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context)
        : base(context)
    {
    }

    public Task<Produto?> ObterProduto(Guid id)
    {
        return GetByIdAsync(id);
    }

    public Task<IEnumerable<Produto>> ListarProdutos()
    {
        return GetAllAsync();
    }
}
