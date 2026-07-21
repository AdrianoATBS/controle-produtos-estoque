namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.ReativarCategoriaUseCase;

public interface IReativarCategoriaUseCase
{
    Task Executar(Guid id);
}
