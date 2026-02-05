using Microsoft.Extensions.DependencyInjection;
using Orderly.Application.Interfaces.Services;
using Orderly.Application.Services;

namespace Orderly.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationModule));

        services.AddScoped<IClienteAppService, ClienteAppService>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IPedidoAppService, PedidoAppService>();

        return services;
    }
}

