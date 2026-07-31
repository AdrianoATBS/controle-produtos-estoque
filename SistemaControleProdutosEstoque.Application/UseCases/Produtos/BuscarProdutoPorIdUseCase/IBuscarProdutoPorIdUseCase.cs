using SistemaControleProdutosEstoque.Application.Responses.Produtos;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutoPorIdUseCase;

public interface IBuscarProdutoPorIdUseCase
{
    Task<BuscarProdutoPorIdResponse> Executar(Guid id);
}
