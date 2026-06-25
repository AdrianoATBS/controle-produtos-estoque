using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Application.Validators.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;
using FluentValidation;

namespace SistemaControleProdutosEstoque.Application.UseCases;

public class CriarCategoriaUseCase : ICriarCategoriaUseCase
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly CriarCategoriaRequestValidator _validator;
    public CriarCategoriaUseCase(ICategoriaRepository categoriaRepository, CriarCategoriaRequestValidator validator)
    {
        _categoriaRepository = categoriaRepository;
        _validator = validator;
    }
    public async Task<CriarCategoriaResponse> Executar(CriarCategoriaRequest request)
    {
        var  resultadoValidacao = await _validator.ValidateAsync(request);
        if (!resultadoValidacao.IsValid)
            throw new ValidationException(resultadoValidacao.Errors);

        var jaExiste = _categoriaRepository.ExisteCategoriaComNome(request.Nome);
        if(jaExiste)
                throw new InvalidOperationException("Já existe uma categoria com o mesmo nome.");

        var novaCategoria = Domain.Entities.Categoria.Criar(request.Nome);

        _categoriaRepository.AdicionarCategoria(novaCategoria);
        
        var response = new CriarCategoriaResponse
        {
            Id = novaCategoria.Id,
            Nome = novaCategoria.Nome,
            Ativo = novaCategoria.Ativo,
            DataCriacao = novaCategoria.DataCriacao
        };
        return response;
    }
}
