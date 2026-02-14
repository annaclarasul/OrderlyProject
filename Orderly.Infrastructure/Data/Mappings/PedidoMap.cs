using AutoMapper;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Models;

public class PedidoMap : Profile
{
    public PedidoMap()
    {
        CreateMap<Pedido, PedidoPersistencia>().ReverseMap();
        CreateMap<PedidoItem, PedidoItemPersistencia>().ReverseMap();
        CreateMap<Cliente, ClientePersistencia>().ReverseMap();
    }
}




