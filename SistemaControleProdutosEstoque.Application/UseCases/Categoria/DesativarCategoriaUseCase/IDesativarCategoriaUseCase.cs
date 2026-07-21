using SistemaControleProdutosEstoque.Application.Responses.Categorias;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.DesativarCategoriaUseCase;

public interface IDesativarCategoriaUseCase
{
    Task Executar(Guid id);
}
