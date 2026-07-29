namespace SistemaControleProdutosEstoque.Application.Requests.Produto;

public class AlterarProdutoRequest
{
    public string NovoNome { get; set; } = string.Empty;
    public string NovaDescricao { get; set; } = string.Empty;
    public decimal NovoPreco { get; set; }
    public int NovoEstoque { get; set; }

}
