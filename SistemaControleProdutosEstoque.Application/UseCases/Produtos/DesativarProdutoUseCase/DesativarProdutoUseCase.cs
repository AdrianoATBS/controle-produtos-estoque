using SistemaControleProdutosEstoque.Application.Exceptions;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarProdutoUseCase;

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
            throw new NotFoundException("Produto não encontrado");

        produto.Desativar();
        await _produtoRepository.AtualizarProdutoAsync(produto);
    }
}
