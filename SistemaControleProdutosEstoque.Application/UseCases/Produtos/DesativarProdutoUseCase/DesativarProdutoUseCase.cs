using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarCategoriaUseCase;

public class DesativarProdutoUseCase : IDesativarProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    public DesativarProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task Executar(Guid id)
    {
        var produto = await _produtoRepository.ObterProdutoIdAsync(id);
        if(produto == null)  
            throw new ArgumentException("Produto não encontrado");

        produto.Desativar();
        await _produtoRepository.AtualizarProdutoAsync(produto);
    }
}
