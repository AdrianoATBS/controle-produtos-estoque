using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Domain.Interfaces;

public interface IMovimentacaoEstoqueRepository
{
    void RegistrarMovimentacaoEstoque(MovimentacaoEstoque movimentacaoEstoque);
    MovimentacaoEstoque? ObterMovimentacao(Guid id);
    IEnumerable<MovimentacaoEstoque> ObterTodasMovimentacoes();
    IEnumerable<MovimentacaoEstoque> ObterMovimentacaoEstoqueData(DateTime data);
    MovimentacaoEstoque? ObterUltimaMovimentacaoPorProduto(Guid produtoId);

}
