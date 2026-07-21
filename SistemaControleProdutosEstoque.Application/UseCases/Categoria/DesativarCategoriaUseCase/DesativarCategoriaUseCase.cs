using SistemaControleProdutosEstoque.Application.Responses.Categorias;
using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.DesativarCategoriaUseCase;

public class DesativarCategoriaUseCase : IDesativarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;
    public DesativarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task Executar(Guid id)
    {
       var categoria =  await _repository.ObterCategoriaIdAsync(id);
        if(categoria == null) 
            throw new ArgumentException("Categoria não encontrada");

        categoria.Desativar();
        _repository.AtualizarCategoria(categoria);
      
       
       
    }


}
