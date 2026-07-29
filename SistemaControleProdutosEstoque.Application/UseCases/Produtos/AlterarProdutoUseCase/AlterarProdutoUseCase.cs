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
        var validator = await _validator.ValidateAsync(request);
        if(!validator.IsValid)
                throw new Exception("Request inválido");

        var produto = await _produtoRepository.ObterProdutoIdAsync(id);
        if(produto == null)
                throw new KeyNotFoundException("Produto não encontrado");

        var jaExisteProdutoComMesmoNome = await _produtoRepository.ExisteProdutoComNomeAsync(request.NovoNome);
        if(jaExisteProdutoComMesmoNome)
            throw new Exception("Já existe um produto com o mesmo nome");

        return new AlterarProdutoResponse
        {
            Id = id,
            Nome = request.NovoNome,
            Descricao = request.NovaDescricao,
            Preco = request.NovoPreco,
            QuantidadeEstoque = request.NovoEstoque
        };
    }
}
