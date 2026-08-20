using SistemaControleProdutosEstoque.Domain.Enums;

namespace SistemaControleProdutosEstoque.Application.Responses.Estoque;

public class BuscarUltimaMovimentacaoDoProdutoResponse
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public TipoMovimentacao TipoEstoque { get; set; }
    public string DataCriacao { get; set; } = string.Empty;
}
