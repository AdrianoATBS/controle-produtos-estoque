using SistemaControleProdutosEstoque.Application.Exceptions;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.DeletarProdutoUseCase;

public class DeletarProdutoUseCase : IDeletarProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    public DeletarProdutoUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task Executar(Guid id)
    {
        var produto = await _produtoRepository.ObterProdutoIdAsync(id);
        if(produto == null)
                throw new NotFoundException("O produto não foi encontrado.");
        
        if(produto.Ativo)
            throw new BusinessException("Não é possível excluir um produto ativo.");

        await _produtoRepository.DeletarProdutoAsync(produto.Id);
    }
}
