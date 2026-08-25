using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Estoque;
using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Application.Validators.Estoque;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.FiltrarPorPeriodoUseCase;

public class FiltrarPorPeriodoUseCase : IFiltrarPorPeriodoUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly FiltrarPorPeriodoRequestValidator _validator;
    public FiltrarPorPeriodoUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository,
        FiltrarPorPeriodoRequestValidator validator)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _validator = validator;
    }
    public async Task<List<FiltrarPorPeriodoResponse>> Executar(FiltrarPorPeriodoRequest request)
    {
        var resultadoValidacao = await _validator.ValidateAsync(request);
        if (!resultadoValidacao.IsValid)
            throw new ValidationException(resultadoValidacao.Errors);

        var movimentacoes = await _movimentacaoEstoqueRepository.ObterMovimentacoesPorPeriodoAsync
            (request.DataInicio, request.DataFim);


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
