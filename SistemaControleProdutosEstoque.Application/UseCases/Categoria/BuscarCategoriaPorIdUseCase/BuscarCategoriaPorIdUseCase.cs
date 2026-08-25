using SistemaControleProdutosEstoque.Application.Exceptions;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;

public class BuscarCategoriaPorIdUseCase : IBuscarCategoriaPorIdUseCase
{
    private readonly ICategoriaRepository _categoriaRepository;


    public BuscarCategoriaPorIdUseCase(ICategoriaRepository categoriaRepository
        )
    {
        _categoriaRepository = categoriaRepository;
    }
    public async Task<BuscarCategoriaPorIdResponse> Executar(Guid id)
    {
        
        var categoria = await _categoriaRepository.ObterCategoriaIdAsync(id);
        if(categoria == null)
            throw new NotFoundException("Categoria não encontrada.");

       

        return new BuscarCategoriaPorIdResponse
        {
            Nome = categoria.Nome,
            Ativo = categoria.Ativo,
            DataCadastro = categoria.DataCriacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")
        };
        
    }
}
