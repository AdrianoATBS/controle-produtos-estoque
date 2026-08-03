namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarProdutoUseCase;

public interface IDesativarProdutoUseCase
{
    Task Executar(Guid id);
}
