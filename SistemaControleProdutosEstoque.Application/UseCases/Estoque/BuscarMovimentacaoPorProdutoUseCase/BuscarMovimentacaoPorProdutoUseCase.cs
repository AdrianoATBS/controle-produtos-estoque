using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;

public class BuscarMovimentacaoPorProdutoUseCase : IBuscarMovimentacaoPorProdutoUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IProdutoRepository _produtoRepository;
    public BuscarMovimentacaoPorProdutoUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository, IProdutoRepository produtoRepository)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _produtoRepository = produtoRepository;
    }
    public async Task<List<BuscarMovimentacaoPorProdutoResponse>> Executar(Guid produtoId)
    {

        var movimentacoes = await _movimentacaoEstoqueRepository.ObterMovimentacaoDoProdutoIdAsync(produtoId);
        if(movimentacoes == null)
    
            throw new ArgumentException("Movimentação não encontrada");

        return movimentacoes.Select(m => new BuscarMovimentacaoPorProdutoResponse
        {
            Id = m.Id,
            ProdutoId = m.ProdutoId,
            NomeProduto = m.Produto.Nome,
            Quantidade = m.Quantidade,
            TipoEstoque = m.Tipo,
            DataMovimentacao = m.DataMovimentacao.ToString("dd/MM/yyyy HH:mm:ss")
        }).ToList();
    }
}
