using SistemaControleProdutosEstoque.Application.Responses.Estoque;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;

public interface IBuscarMovimentacaoPorProdutoUseCase
{
    Task<List<BuscarMovimentacaoPorProdutoResponse>> Executar(Guid produtoId);
}
