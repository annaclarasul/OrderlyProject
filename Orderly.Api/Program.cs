using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Orderly.Application;
using Orderly.Infrastructure;
using System;
using System.IO;


var builder = WebApplication.CreateBuilder(args);

// =======================
// CONTROLLERS
// =======================
builder.Services.AddControllers();

// =======================
// SWAGGER PROFISSIONAL
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


// =======================
// DEPENDENCY INJECTION
// =======================
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

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

