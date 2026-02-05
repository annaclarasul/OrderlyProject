using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orderly.Domain.Models;

namespace Orderly.Infrastructure.Data.Mappings;

public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.ToTable("PedidoItens");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever();

        builder.Property(i => i.ProdutoId)
            .IsRequired();

        builder.Property(i => i.PrecoUnitario)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(i => i.Quantidade)
            .IsRequired();
    }
}



