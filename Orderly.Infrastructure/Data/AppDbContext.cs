using Microsoft.EntityFrameworkCore;
using Orderly.Domain.Models;
using Orderly.Infrastructure.Models;

namespace Orderly.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<ClientePersistencia> Clientes => Set<ClientePersistencia>();
    public DbSet<ProdutoPersistencia> Produtos => Set<ProdutoPersistencia>();
    public DbSet<PedidoPersistencia> Pedidos => Set<PedidoPersistencia>();
    public DbSet<PedidoItemPersistencia> PedidoItens => Set<PedidoItemPersistencia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );

        base.OnModelCreating(modelBuilder);
    }
}




