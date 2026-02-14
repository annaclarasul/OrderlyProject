using AutoMapper;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Models;

public class ClienteMap : Profile
{
    public ClienteMap()
    {
        CreateMap<Cliente, ClientePersistencia>().ReverseMap();
    }
}



