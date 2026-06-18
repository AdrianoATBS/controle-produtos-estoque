using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Infrastructure.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public  void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Ativo)
            .IsRequired()
            .HasColumnType("BIT");

        builder.Property(c => c.DataCriacao)
            .IsRequired()
            .HasColumnType("DATETIME");
           
    }
}
