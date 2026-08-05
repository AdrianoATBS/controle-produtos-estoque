using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutosPorCategoriaUseCase;

public class BuscarProdutosPorCategoriaUseCase : IBuscarProdutosPorCategoriaUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    public BuscarProdutosPorCategoriaUseCase(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public async Task<IEnumerable<BuscarProdutosPorCategoriaResponse>> Executar(
        Guid id)
    {
        var produto = await _produtoRepository.ObterProdutosPorCategoriaAsync(id);
        

        return produto.Select(p => new BuscarProdutosPorCategoriaResponse { 
            CategoriaId = p.CategoriaId,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Ativo = p.Ativo,
            NomeCategoria = p.Categoria?.Nome ?? "Sem categoria",
            DataCriacao = p.DataCriacao
        });


    }
}
