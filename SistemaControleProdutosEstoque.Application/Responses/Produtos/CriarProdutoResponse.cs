namespace SistemaControleProdutosEstoque.Application.Responses.Produtos;

public class CriarProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set;} = string.Empty;
    public Decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public bool Ativo { get; set; }
    public string DataCriacao { get; set;} = string.Empty;

}
