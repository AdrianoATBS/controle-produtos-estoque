using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Domain.Interfaces;

public interface IProdutoRepository
{
    void AdicionarProduto(Produto produto);
    void AtualizarProduto(Produto produto);
    void DeletarProduto(Guid id);
    IEnumerable<Produto> ObterTodosOsProdutos();
    IEnumerable<Produto> ObterProdutosPorCategoria(Guid categoriaId);
    Produto? ObterProduto(Guid id);
    
    IEnumerable<Produto> ObterProdutosPorNome(string nome);

}
