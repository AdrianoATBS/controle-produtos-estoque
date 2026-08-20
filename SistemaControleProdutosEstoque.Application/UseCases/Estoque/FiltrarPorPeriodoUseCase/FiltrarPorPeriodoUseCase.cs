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
        var movimentacoes = await _movimentacaoEstoqueRepository.ObterMovimentacoesPorPeriodoAsync
            (request.DataInicio, request.DataFim);

        if(request.DataInicio > request.DataFim)
            throw new ArgumentException("A data de início não pode ser maior que a data de fim.");
        if(request.DataFim > request.DataInicio)
            throw new ArgumentException("A data de fim não pode ser menor que a data de início.");


        return movimentacoes.Select(m => new FiltrarPorPeriodoResponse { 
           Id = m.Id,
           ProdutoId = m.ProdutoId,
           NomeProduto = m.Produto.Nome,
           Quantidade = m.Quantidade,
           TipoEstoque = m.Tipo,
           DataMovimentacao = m.DataMovimentacao.ToString("dd/MM/yyyy")

       }).ToList();
       
    }
}
