using AutoMapper;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Mappings;

public class ProdutoMap : Profile
{
    public ProdutoMap()
    {
        CreateMap<Produto, ProdutoPersistencia>();

        CreateMap<ProdutoPersistencia, Produto>()
            .ConstructUsing(p => new Produto(
                p.Nome,
                p.Preco,
                p.Estoque
            ));
    }
}