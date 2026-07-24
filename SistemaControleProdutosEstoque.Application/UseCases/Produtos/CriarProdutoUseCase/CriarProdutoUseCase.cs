using SistemaControleProdutosEstoque.Application.Requests.Produto;
using SistemaControleProdutosEstoque.Application.Responses.Produtos;
using SistemaControleProdutosEstoque.Application.Validators.Produtos;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;

public class CriarProdutoUseCase : ICriarProdutoUseCase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly CriarProdutoRequestValidator _validator;
    private readonly ICategoriaRepository _categoriaRepository;
    public CriarProdutoUseCase(IProdutoRepository produtoRepository,
        CriarProdutoRequestValidator validator
        ,ICategoriaRepository categoriaRepository)
    {
        _produtoRepository = produtoRepository;
        _validator = validator;
        _categoriaRepository = categoriaRepository;
    }
    public async Task<CriarProdutoResponse> Executar(CriarProdutoRequest request)
    {
        var validator = await _validator.ValidateAsync(request);
        if (!validator.IsValid)
            throw new Exception($"Dados inválidos ${string.Join(", ", validator.Errors.Select(e => e.ErrorMessage))} ");
        
        var jaExiste = await _produtoRepository.ExisteProdutoComNomeAsync(request.Nome);
        if(jaExiste)
            throw new Exception($"Já existe um produto com o nome {request.Nome} cadastrado.");

        var categoriaEntidade = await _categoriaRepository.ObterCategoriaIdAsync(request.CategoriaId);
        
        if(categoriaEntidade == null)
            throw new KeyNotFoundException($"A categoria informada não existe.");
        if(!categoriaEntidade.Ativo)
                throw new InvalidOperationException("Não é possivel associar um produto a uma categoria inativa.");

        var novoProduto = Domain.Entities.Produto.Criar(
            request.Nome,
            request.Descricao,
            request.Preco,
            request.QuantidadeEstoque,
            categoriaEntidade
        );
        await _produtoRepository.AdicionarProdutoAsync(novoProduto);
        return new CriarProdutoResponse
        {
            Id = novoProduto.Id,
            Nome = novoProduto.Nome,
            Descricao = novoProduto.Descricao,
            Preco = novoProduto.Preco,
            QuantidadeEstoque = novoProduto.QuantidadeEstoque,
            Ativo = novoProduto.Ativo,
            DataCriacao = novoProduto.DataCriacao.ToString("yyyy-MM-dd HH:mm:ss")
        };
    }
}
