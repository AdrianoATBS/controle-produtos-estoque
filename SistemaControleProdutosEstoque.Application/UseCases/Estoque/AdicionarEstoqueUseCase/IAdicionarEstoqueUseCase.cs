using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.Responses.Estoque;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;

public interface IAdicionarEstoqueUseCase
{
    Task<AdicionarEstoqueResponse> Executar(AdicionarEstoqueRequest request);

}
