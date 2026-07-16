using SistemaControleProdutosEstoque.Application.Responses.Categorias;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.ListarTodasCategoria;

public interface IListaTodasCategoriaUseCase
{
    Task<IList<ListaTodasCategoriaResponse>> Executar();
}
