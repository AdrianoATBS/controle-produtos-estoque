using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutosPorCategoriaUseCase;

public interface IBuscarProdutosPorCategoriaUseCase
{
    Task<IEnumerable<BuscarProdutosPorCategoriaResponse>> Executar(Guid id);

}
