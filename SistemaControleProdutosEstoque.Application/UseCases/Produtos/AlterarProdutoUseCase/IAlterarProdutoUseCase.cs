using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;

public interface IAlterarProdutoUseCase
{
    Task<AlterarProdutoResponse> Executar(Guid id, AlterarProdutoRequest request);
}
