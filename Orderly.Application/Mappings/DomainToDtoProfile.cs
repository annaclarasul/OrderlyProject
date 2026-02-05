using AutoMapper;
using Orderly.Application.DTOs.Cliente;
using Orderly.Application.DTOs.Pedido;
using Orderly.Application.DTOs.Produto;
using Orderly.Domain.Models;

namespace Orderly.Application.Mappings;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Cliente, ClienteResponse>()
            .ForMember(d => d.Email,
                opt => opt.MapFrom(s => s.Email.Value));

        CreateMap<Produto, ProdutoResponse>();

        CreateMap<PedidoItem, PedidoItemResponse>()
         .ForMember(dest => dest.NomeProduto,
             opt => opt.MapFrom(src => src.Produto.Nome))
         .ForMember(dest => dest.PrecoUnitario,
             opt => opt.MapFrom(src => src.Produto.Preco))
         .ForMember(dest => dest.Subtotal,
             opt => opt.MapFrom(src => src.Quantidade * src.Produto.Preco));

        CreateMap<Pedido, PedidoResponse>()
            .ForMember(d => d.Cliente,
                opt => opt.MapFrom(s => s.Cliente.Nome))
            .ForMember(d => d.Status,
                opt => opt.MapFrom(s => s.Status.ToString()))
            .ForMember(d => d.Total,
                opt => opt.MapFrom(s => s.CalcularTotal()));

 

    }
}


