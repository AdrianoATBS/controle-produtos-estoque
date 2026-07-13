namespace SistemaControleProdutosEstoque.Application.Responses.Categorias;

public class AlterarNomeCategoriaResponse
{
    public Guid Id { get; set; }
    public string NovoNome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}
