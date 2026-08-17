using SistemaControleProdutosEstoque.Domain.Enums;

namespace SistemaControleProdutosEstoque.Domain.Entities;

public class MovimentacaoEstoque
{
    public Guid Id { get; private set; }
    public Guid ProdutoId { get; private set; }
    public Produto Produto { get; private set; } 
    public TipoMovimentacao Tipo { get; private set; }
    public int Quantidade { get; private set; }
    public DateTime DataMovimentacao { get; private set; }
    private MovimentacaoEstoque() { }

    private MovimentacaoEstoque(Produto produto, TipoMovimentacao tipo, int quantidade)
    {
        Id = Guid.NewGuid();
        ProdutoId = produto.Id;
        Produto = produto;
        Tipo = tipo;
        Quantidade = quantidade;
        DataMovimentacao = DateTime.Now;
    }
    public static MovimentacaoEstoque Criar(Produto? produto, TipoMovimentacao tipo, int quantidade)
    {
        ValidarProduto(produto);
        ValidarQuantidade(quantidade);
        ValidarRegrasEstoque(produto!, tipo, quantidade);
        return new MovimentacaoEstoque(produto!, tipo, quantidade);

    }

    
    
    private static void ValidarProduto(Produto? produto)
    {
        if (produto == null)
            throw new ArgumentNullException("O produto é obrigatório para a movimentação de estoque.");
        if (!produto.Ativo)
            throw new InvalidOperationException("Não é possível realizar uma movimentação de estoque para um produto desativado.");
    }

    private static void ValidarQuantidade(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade da movimentação deve ser maior que zero.");
    }
    private static void ValidarRegrasEstoque(Produto produto, TipoMovimentacao tipo, int quantidade)
    {
        if (tipo == TipoMovimentacao.Saida && produto.QuantidadeEstoque < quantidade)
            throw new InvalidOperationException("Não é possível realizar uma saída de estoque com quantidade maior que a disponível.");
    }

}
