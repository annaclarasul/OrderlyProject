using AutoMapper;
using Orderly.Api.DTOs;
using Orderly.Api.Models;

namespace Orderly.Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // PRODUCTS
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();

        // ORDERS (SAÍDA)
        CreateMap<Order, OrderDto>()
            .ForMember(
                dest => dest.Total,
                opt => opt.MapFrom(src => src.Total)
            );

        CreateMap<OrderItem, OrderItemDto>();

        // ORDERS (ENTRADA)
        CreateMap<CreateOrderDto, Order>();
        CreateMap<CreateOrderItemDto, OrderItem>();
    }
}
