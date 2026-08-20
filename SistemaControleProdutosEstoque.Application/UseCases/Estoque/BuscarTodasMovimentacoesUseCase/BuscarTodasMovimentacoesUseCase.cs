using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarTodasMovimentacoesUseCase;

public class BuscarTodasMovimentacoesUseCase : IBuscarTodasMovimentacoesUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    private readonly IProdutoRepository _produtoRepository;
    public BuscarTodasMovimentacoesUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository,
        IProdutoRepository produtoRepository)
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;
        _produtoRepository = produtoRepository;
    }
    public async Task<IEnumerable<BuscarTodasMovimentacoesResponse>> Executar()
    {

        var movimentacoes = await _movimentacaoEstoqueRepository.ObterTodasMovimentacoesAsync();
        if(movimentacoes == null)
            throw new Exception("Não foi possível obter as movimentações de estoque.");

       return movimentacoes.Select(m => new BuscarTodasMovimentacoesResponse {
            Id = m.Id,
            ProdutoId = m.ProdutoId,
            Nome = m.Produto.Nome,
            Quantidade = m.Quantidade,
            TipoEstoque = m.Tipo,
            DataCriacao = m.DataMovimentacao.ToString("dd/MM/yyyy HH:mm:ss")

        }).ToList();

        
    }
}
