namespace SistemaControleProdutosEstoque.Application.Responses.Produtos;

public class AlterarProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }

}
