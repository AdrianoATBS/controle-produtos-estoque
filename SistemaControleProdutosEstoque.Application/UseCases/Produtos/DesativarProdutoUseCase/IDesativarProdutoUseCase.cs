namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarCategoriaUseCase;

public interface IDesativarProdutoUseCase
{
    Task Executar(Guid id);
}
