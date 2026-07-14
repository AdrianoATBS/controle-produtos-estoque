using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;

public interface IBuscarCategoriaPorIdUseCase
{
    Task<BuscarCategoriaPorIdResponse> Executar(Guid id );
}
