using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orderly.Domain.Models;

namespace Orderly.Infrastructure.Data.Mappings;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(p => p.Estoque)
            .IsRequired();
    }
}




