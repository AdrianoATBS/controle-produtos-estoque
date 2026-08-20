using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.Responses.Estoque;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.FiltrarPorPeriodoUseCase;

public interface IFiltrarPorPeriodoUseCase
{
    Task<List<FiltrarPorPeriodoResponse>> Executar(FiltrarPorPeriodoRequest request);
}
