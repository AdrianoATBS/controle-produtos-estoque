using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Application.Validators.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;

public class BuscarCategoriaPorIdUseCase : IBuscarCategoriaPorIdUseCase
{
    private readonly ICategoriaRepository _categoriaRepository;


    public BuscarCategoriaPorIdUseCase(ICategoriaRepository categoriaRepository
        )
    {
        _categoriaRepository = categoriaRepository;
    }
    public Task<BuscarCategoriaPorIdResponse> Executar(Guid id)
    {
        
        var categoria = _categoriaRepository.ObterCategoriaId(id);
        if(categoria == null)
            throw new ValidationException("Categoria não encontrada.");

       

        var response = new BuscarCategoriaPorIdResponse
        {
            Nome = categoria.Nome,
            Ativo = categoria.Ativo,
            DataCadastro = categoria.DataCriacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")
        };
        return Task.FromResult(response);
    }
}
