using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;

public interface ICriarCategoriaUseCase
{
    Task<CriarCategoriaResponse> Executar(CriarCategoriaRequest request);
}
