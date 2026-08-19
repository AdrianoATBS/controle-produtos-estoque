using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarUltimaMovimentacaoDoProdutoUseCase;

public class BuscarUltimaMovimentacaoDoProdutoUseCase : IBuscarUltimaMovimentacaoDoProdutoUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IProdutoRepository _produtoRepository;
    public BuscarUltimaMovimentacaoDoProdutoUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository, IProdutoRepository produtoRepository)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _produtoRepository = produtoRepository;
    }
    public async Task<BuscarUltimaMovimentacaoDoProdutoResponse> Executar(Guid produtoId)
    {
        var produto = await _produtoRepository.ObterProdutoIdAsync(produtoId);
        if(produto == null) throw new ArgumentException("Produto não encontrado");

        var ultimaMovimentacao = await _movimentacaoEstoqueRepository.ObterUltimaMovimentacaoPorProdutoAsync(produtoId);
        if (ultimaMovimentacao == null) throw new ArgumentException("Nenhuma movimentação encontrada");
        
        return new BuscarUltimaMovimentacaoDoProdutoResponse
        {
            Id = ultimaMovimentacao.Id,
            ProdutoId = ultimaMovimentacao.ProdutoId,
            Nome = produto.Nome,
            Quantidade = ultimaMovimentacao.Quantidade,
            TipoEstoque = ultimaMovimentacao.Tipo,
            DataCriacao = ultimaMovimentacao.DataMovimentacao.ToString("dd/MM/yyyy HH:mm:ss")
        };

    }
}
