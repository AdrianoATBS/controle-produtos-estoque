using SistemaControleProdutosEstoque.Application.Exceptions;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutoPorIdUseCase;

public class BuscarProdutoPorIdUseCase : IBuscarProdutoPorIdUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    public BuscarProdutoPorIdUseCase(IProdutoRepository produtoRepository 
       )
    {
        _produtoRepository = produtoRepository;
       
    }
    public async Task<BuscarProdutoPorIdResponse> Executar(Guid id)
    {
        var produto = await _produtoRepository.ObterProdutoIdAsync(id);
        if (produto == null)
            throw new NotFoundException("Produto não encontrado");

  

        return new BuscarProdutoPorIdResponse
        {
            Id = id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Ativo = produto.Ativo,
            NomeCategoria = produto.Categoria.Nome, 
            DataCriacao = produto.DataCriacao
        };

    }
}
