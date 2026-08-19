using SistemaControleProdutosEstoque.Application.Responses.Estoque;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarUltimaMovimentacaoDoProdutoUseCase;

public interface IBuscarUltimaMovimentacaoDoProdutoUseCase
{
    Task<BuscarUltimaMovimentacaoDoProdutoResponse> Executar(Guid produtoId);
}
