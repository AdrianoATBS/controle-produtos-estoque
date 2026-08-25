using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Application.Validators.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarCategoriaUseCase;
using FluentValidation;
using SistemaControleProdutosEstoque.Application.Exceptions;

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

        var jaExiste = await _categoriaRepository.ExisteCategoriaComNomeAsync(request.Nome);
        if(jaExiste)
                throw new BusinessException("Já existe uma categoria com o mesmo nome.");

        var novaCategoria = Domain.Entities.Categoria.Criar(request.Nome);

        await _categoriaRepository.AdicionarCategoriaAsync(novaCategoria);
        
        var response = new CriarCategoriaResponse
        {
            Id = novaCategoria.Id,
            Nome = novaCategoria.Nome,
            Ativo = novaCategoria.Ativo,
            DataCriacao = novaCategoria.DataCriacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")
        };
        return response;
    }
}
