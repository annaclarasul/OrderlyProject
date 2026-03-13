using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Orderly.Application;
using Orderly.Domain.Interfaces.Repositories;
using Orderly.Domain.Interfaces.Services;
using Orderly.Domain.Services;
using Orderly.Infrastructure;
using Orderly.Infrastructure.Data;
using System;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

// =======================
// CONTROLLERS
// =======================
builder.Services.AddControllers();

// =======================
// SWAGGER 
// =======================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Orderly API",
        Version = "v1",
        Description = "API profissional para gestão de Clientes, Produtos e Pedidos",
        Contact = new OpenApiContact
        {
            Name = "Orderly Team"
        }
    });

    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(
        Path.Combine(AppContext.BaseDirectory, xmlFilename)
    );
});


// DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Application Services
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();
builder.Services.AddScoped<IProdutoAppService, ProdutoAppService>();
builder.Services.AddScoped<IPedidoAppService, PedidoAppService>();

// Repositories
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();


// =======================
// APP
// =======================
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "Orderly API Docs";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orderly API v1");
        c.RoutePrefix = "swagger";

    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();

