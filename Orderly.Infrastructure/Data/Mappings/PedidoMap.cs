using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orderly.Domain.Models;

namespace Orderly.Infrastructure.Data.Mappings;

public class PedidoMap : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Status)
            .IsRequired();

        builder.HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Itens)
            .WithOne()
            .HasForeignKey("PedidoId")
            .OnDelete(DeleteBehavior.Cascade);


    }
}




