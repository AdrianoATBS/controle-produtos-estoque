using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Infrastructure.Configurations;

public class MovimentacaoEstoqueConfiguration : IEntityTypeConfiguration<MovimentacaoEstoque>
{
    public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
    {
        builder.ToTable("MovimentacoesEstoque");

        builder.HasKey(m => m.Id);

        builder.HasOne(p => p.Produto)
            .WithMany()
            .HasForeignKey(m => m.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(m => m.Tipo)
            .IsRequired()
            .HasMaxLength(20)
            .HasConversion<string>();

        builder.Property(m => m.Quantidade)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(m => m.DataMovimentacao)
            .IsRequired()
            .HasColumnType("DATETIME");
            

    }

}

