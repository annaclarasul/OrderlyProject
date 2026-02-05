using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orderly.Application.Interfaces;
using Orderly.Application.Services;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Infrastructure.Data;
using Orderly.Infrastructure.Repositories;
using Orderly.Application.Interfaces.Services;
using System;

namespace Orderly.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString)
        {
            // Database
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Services
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}
