using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Domain.Interfaces;

public interface IProdutoRepository
{
    Task AdicionarProdutoAsync(Produto produto);
    Task AtualizarProdutoAsync(Produto produto);
    Task DeletarProdutoAsync(Guid id);
    Task<bool> ExisteProdutoComNomeAsync(string nome);
    Task<bool> ExisteProdutoNaCategoriaAsync(Guid categoriaId);

    Task<IEnumerable<Produto>> ObterTodosOsProdutosAsync();

    Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(Guid categoriaId);
    Task<Produto?> ObterProdutoIdAsync(Guid id);
    Task<bool> ExisteProdutoComNomeParaAlteracaoAsync(string nome, Guid idAtual);
    Task<IEnumerable<Produto>> ObterProdutosPorNomeAsync(string nome);

}
