using AutoMapper;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Models;
public class ProdutoRepository
    : RepositoryBase<Produto, ProdutoPersistencia>,
      IProdutoRepository
{
    public ProdutoRepository(AppDbContext context, IMapper mapper)
        : base(context, mapper)
    {
    }
}
