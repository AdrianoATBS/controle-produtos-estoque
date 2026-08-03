namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.DeletarProdutoUseCase;

public interface IDeletarProdutoUseCase
{
    Task Executar(Guid id);
}
