using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;

public interface ICriarProdutoUseCase
{
    Task<CriarProdutoResponse> Executar(CriarProdutoRequest request);
}
