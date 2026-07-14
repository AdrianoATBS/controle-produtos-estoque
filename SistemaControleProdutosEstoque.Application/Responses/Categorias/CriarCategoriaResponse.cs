namespace SistemaControleProdutosEstoque.Application.Responses.Categorias;

public class CriarCategoriaResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string DataCriacao { get; set; } = string.Empty;
}
