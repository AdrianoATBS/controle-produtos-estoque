using SistemaControleProdutosEstoque.Domain.Enums;

namespace SistemaControleProdutosEstoque.Application.Requests.Estoque;

public class AdicionarEstoqueRequest
{
    public int Quantidade { get; set; }
    public Guid ProdutoId { get; set; }
    public TipoMovimentacao TipoEstoque { get; set; }

}
