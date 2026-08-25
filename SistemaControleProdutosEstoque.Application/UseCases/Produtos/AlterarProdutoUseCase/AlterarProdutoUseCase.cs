using FluentValidation;
using SistemaControleProdutosEstoque.Application.Exceptions;
using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;
using SistemaControleProdutosEstoque.Application.Validators.Produtos;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;

public class AlterarProdutoUseCase : IAlterarProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly AlterarProdutoRequestValidator _validator;

    public AlterarProdutoUseCase(IProdutoRepository produtoRepository, 
        AlterarProdutoRequestValidator validator)
    {
        _produtoRepository = produtoRepository;
        _validator = validator;
    }
    public async Task<AlterarProdutoResponse> Executar(Guid id,AlterarProdutoRequest request)
    {
        var resultadoValidacao = await _validator.ValidateAsync(request);
        if(!resultadoValidacao.IsValid)
                throw new ValidationException(resultadoValidacao.Errors);

        var produto = await _produtoRepository.ObterProdutoIdAsync(id);
        if(produto == null)
                throw new NotFoundException("Produto não encontrado");

        var jaExisteProdutoComMesmoNome = await _produtoRepository.
            ExisteProdutoComNomeParaAlteracaoAsync(request.NovoNome, id);
        if(jaExisteProdutoComMesmoNome)
            throw new BusinessException("Já existe um produto com o mesmo nome");

        produto.AlterarDados(
            request.NovoNome,
            request.NovaDescricao,
            request.NovoPreco
         );
        await _produtoRepository.AtualizarProdutoAsync(produto);

        return new AlterarProdutoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco
        };
    }
}
