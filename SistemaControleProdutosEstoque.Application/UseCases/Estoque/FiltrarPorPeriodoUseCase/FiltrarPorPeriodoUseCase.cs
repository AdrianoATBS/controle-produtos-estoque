using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.FiltrarPorPeriodoUseCase;

public class FiltrarPorPeriodoUseCase : IFiltrarPorPeriodoUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    public FiltrarPorPeriodoUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
    }
    public async Task<List<FiltrarPorPeriodoResponse>> Executar(FiltrarPorPeriodoRequest request)
    {
        var movimentacoes = await _movimentacaoEstoqueRepository.ObterMovimentacoesPorPeridoAsync
            (request.DataInicio, request.DataFim);

       return movimentacoes.Select(m => new FiltrarPorPeriodoResponse { 
           Id = m.Id,
           ProdutoId = m.ProdutoId,
           NomeProduto = m.Produto.Nome,
           Quantidade = m.Quantidade,
           TipoEstoque = m.Tipo,
           DataCriacao = m.DataMovimentacao.ToString("dd/MM/yyyy")

       }).ToList();
       
    }
}
