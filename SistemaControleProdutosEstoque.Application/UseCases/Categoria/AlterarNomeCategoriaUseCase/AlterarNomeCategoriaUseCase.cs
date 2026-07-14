using FluentValidation;
using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Application.Validators.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.AlterarNomeCategoriaUseCase;

public class AlterarNomeCategoriaUseCase : IAlterarNomeCategoriaUseCase
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly AlterarNomeCategoriaRequestValidator _validator;

    public AlterarNomeCategoriaUseCase(ICategoriaRepository categoriaRepository, 
        AlterarNomeCategoriaRequestValidator validator)
    {
        _categoriaRepository = categoriaRepository;
        _validator = validator;
    }
    public async Task<AlterarNomeCategoriaResponse> Executar(Guid id, AlterarNomeCategoriaRequest request)
    {
        var resultadoValidacao = await _validator.ValidateAsync(request);
        if (!resultadoValidacao.IsValid)
            throw new ValidationException(resultadoValidacao.Errors);
        
        var categoria = _categoriaRepository.ObterCategoriaId(id);
        if(categoria == null)
               throw new KeyNotFoundException("Categoria não encontrada.");
        
        var jaExiste = _categoriaRepository.ExisteCategoriaComNome(request.NovoNome);
        if(jaExiste)
            throw new InvalidOperationException("Já existe uma categoria com esse nome.");

        categoria.AlterarNome(request.NovoNome);

        _categoriaRepository.AtualizarCategoria(categoria);

        return new AlterarNomeCategoriaResponse
        {
            Id = categoria.Id,
            NovoNome = categoria.Nome,
            Ativo = categoria.Ativo
        };



    }
}
