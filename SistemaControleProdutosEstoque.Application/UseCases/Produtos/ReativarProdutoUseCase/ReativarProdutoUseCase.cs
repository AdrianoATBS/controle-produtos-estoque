using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.ReativarProdutoUseCase;

public class ReativarProdutoUseCase : IReativarProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    public ReativarProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task Executar(Guid id)
    {
        var produto = await _produtoRepository.ObterProdutoIdAsync(id);
        if (produto == null)
            throw new ArgumentException("O produto não foi encontrado.");

        produto.Ativar();
        await _produtoRepository.AtualizarProdutoAsync(produto);

    }
}
