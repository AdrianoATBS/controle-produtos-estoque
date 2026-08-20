using SistemaControleProdutosEstoque.Application.Responses.Estoque;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarTodasMovimentacoesUseCase;

public class BuscarTodasMovimentacoesUseCase : IBuscarTodasMovimentacoesUseCase
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoEstoqueRepository;
    public BuscarTodasMovimentacoesUseCase(IMovimentacaoEstoqueRepository movimentacaoEstoqueRepository
    )
    {
        _movimentacaoEstoqueRepository = movimentacaoEstoqueRepository;

    }
    public async Task<IEnumerable<BuscarTodasMovimentacoesResponse>> Executar()
    {

        var movimentacoes = await _movimentacaoEstoqueRepository.ObterTodasMovimentacoesAsync();
        
       return movimentacoes.Select(m => new BuscarTodasMovimentacoesResponse {
            Id = m.Id,
            ProdutoId = m.ProdutoId,
            NomeProduto = m.Produto.Nome,
            Quantidade = m.Quantidade,
            TipoEstoque = m.Tipo,
            DataMovimentacao = m.DataMovimentacao.ToString("dd/MM/yyyy HH:mm:ss")

        }).ToList();

        
    }
}
