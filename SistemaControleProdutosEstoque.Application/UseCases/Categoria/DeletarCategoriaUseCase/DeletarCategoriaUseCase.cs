using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.DeletarCategoria;

public class DeletarCategoriaUseCase : IDeletarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;
    public DeletarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }
    public async Task Executar(Guid id)
    {

        var categoria = await _repository.ObterCategoriaIdAsync(id);
        if (categoria == null)
            throw new ArgumentException("Categoria não encontrada");

        if (categoria.Ativo) { 
            throw new ArgumentException("Não é possível deletar uma categoria ativa");
        }

        if(categoria.Produtos != null && categoria.Produtos.Any())
                throw new ArgumentException("Não é possível deletar uma categoria que possui produtos associados");

        await _repository.DeletarCategoriaAsync(id);

    }
}
