namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.ReativarProdutoUseCase;

public interface IReativarProdutoUseCase
{
    Task Executar(Guid id);
}
