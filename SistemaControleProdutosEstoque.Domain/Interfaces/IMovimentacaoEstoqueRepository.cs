using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Domain.Interfaces;

public interface IMovimentacaoEstoqueRepository
{
    Task RegistrarMovimentacaoEstoqueAsync(MovimentacaoEstoque movimentacaoEstoque);
    Task<MovimentacaoEstoque?> ObterMovimentacaoAsync(Guid id);
    Task<IEnumerable<MovimentacaoEstoque>> ObterTodasMovimentacoesAsync();
    Task<MovimentacaoEstoque?> ObterUltimaMovimentacaoPorProdutoAsync(Guid produtoId);


}
