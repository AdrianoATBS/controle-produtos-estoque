using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.ListarTodasCategoria;

public class ListaTodasCategoriaUseCase : IListaTodasCategoriaUseCase
{
    private readonly ICategoriaRepository _categoriaRepository;
    public ListaTodasCategoriaUseCase(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }
    public async Task<IList<ListaTodasCategoriaResponse>> Executar()
    {
        var categorias = await _categoriaRepository.ObterTodasCategoriasAsync();
        
        var response = categorias.Select(c => new ListaTodasCategoriaResponse
        {
            Nome = c.Nome,
            Ativo = c.Ativo
        }).ToList();

        return response;
    }
}
