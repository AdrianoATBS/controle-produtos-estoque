namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.DeletarCategoria;

public interface IDeletarCategoriaUseCase
{
    Task Executar(Guid id);
}
