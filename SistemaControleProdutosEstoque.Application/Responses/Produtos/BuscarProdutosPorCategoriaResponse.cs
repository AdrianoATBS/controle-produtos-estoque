namespace SistemaControleProdutosEstoque.Application.Responses.Produtos;

public class BuscarProdutosPorCategoriaResponse
{
    public Guid CategoriaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string NomeCategoria { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }

}
