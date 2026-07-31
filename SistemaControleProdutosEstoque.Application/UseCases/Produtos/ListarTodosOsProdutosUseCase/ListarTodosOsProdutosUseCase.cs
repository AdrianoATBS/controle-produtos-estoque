using SistemaControleProdutosEstoque.Application.Responses;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.ListarTodosOsProdutosUseCase;

public class ListarTodosOsProdutosUseCase : IListarTodosOsProdutosUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    public ListarTodosOsProdutosUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task<IEnumerable<ListarTodosOsProdutosResponse>> Executar()
    {
        var produtos = await _produtoRepository.ObterTodosOsProdutosAsync();
        if (produtos == null)
            throw new InvalidOperationException("Nenhum produto encontrado");

        var response = produtos.Select(p => new ListarTodosOsProdutosResponse
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            NomeCategoria = p.Categoria.Nome,
        }).ToList();
        return response;
    }
}
