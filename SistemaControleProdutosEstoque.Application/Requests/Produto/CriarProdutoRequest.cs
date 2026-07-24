namespace SistemaControleProdutosEstoque.Application.Requests.Produto;

public class CriarProdutoRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public Decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public Guid CategoriaId { get; set; }

}
