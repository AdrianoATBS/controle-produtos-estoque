using SistemaControleProdutosEstoque.Application.Responses;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.ListarTodosOsProdutosUseCase;

public interface IListarTodosOsProdutosUseCase
{
    Task<IEnumerable<ListarTodosOsProdutosResponse>> Executar();
}
