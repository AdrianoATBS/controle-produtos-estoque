using SistemaControleProdutosEstoque.Application.Responses.Categorias;

namespace SistemaControleProdutosEstoque.Application.UseCases.DesativarCategoriaUseCase;

public interface IDesativarCategoriaUseCase
{
    Task Executar(Guid id);
}
