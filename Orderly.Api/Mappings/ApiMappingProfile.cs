using AutoMapper;
using Orderly.Api.DTOs.Cliente;
using Orderly.Api.DTOs.Pedido;
using Orderly.Api.DTOs.Produto;
using Orderly.Application.DTOs.Cliente;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Models;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        // ===== CLIENTE =====
        CreateMap<CreateClienteRequest, Cliente>();
        CreateMap<UpdateClienteRequestDTO, Cliente>();
        CreateMap<Cliente, ClienteResponseDTO>();
        CreateMap<Cliente, ClientePersistencia>().ReverseMap();

        // ===== PRODUTO =====
        CreateMap<CreateProdutoRequestDTO, Produto>();
        CreateMap<Produto, ProdutoResponseDTO>();
        CreateMap<Produto, ProdutoPersistencia>().ReverseMap();

        // ===== PEDIDO =====
        CreateMap<CreatePedidoRequestDTO, Pedido>();
        CreateMap<Pedido, PedidoResponseDTO>();
        CreateMap<Pedido, PedidoPersistencia>().ReverseMap();
    }
}
