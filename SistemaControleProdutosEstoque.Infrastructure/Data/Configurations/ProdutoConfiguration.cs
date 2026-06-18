using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Infrastructure.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(500);
            
        
        builder.Property(p => p.Preco)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)");
        
        builder.Property(p => p.QuantidadeEstoque)
            .IsRequired()
            .HasColumnType("INT");
       

        builder.HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Ativo)
            .IsRequired()
            .HasColumnType("BIT");

        builder.Property(p => p.DataCriacao)
            .IsRequired()
            .HasColumnType("DATETIME");
            

    }
}
