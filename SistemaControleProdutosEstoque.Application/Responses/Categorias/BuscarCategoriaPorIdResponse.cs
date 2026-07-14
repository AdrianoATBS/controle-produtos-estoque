namespace SistemaControleProdutosEstoque.Application.Responses.Categorias;

public class BuscarCategoriaPorIdResponse
{
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string DataCadastro { get; set; } = string.Empty;

}
