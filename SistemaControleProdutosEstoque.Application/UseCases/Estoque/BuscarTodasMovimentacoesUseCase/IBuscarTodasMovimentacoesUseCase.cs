using SistemaControleProdutosEstoque.Application.Responses.Estoque;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarTodasMovimentacoesUseCase;

public interface IBuscarTodasMovimentacoesUseCase
{
    Task<IEnumerable<BuscarTodasMovimentacoesResponse>> Executar();
}
