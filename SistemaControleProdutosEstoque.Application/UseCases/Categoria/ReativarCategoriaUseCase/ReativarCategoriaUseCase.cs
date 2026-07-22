using SistemaControleProdutosEstoque.Domain.Interfaces;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.ReativarCategoriaUseCase;

public class ReativarCategoriaUseCase : IReativarCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;
    public ReativarCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }
    public async Task Executar(Guid id)
    {
        var categoria = await _repository.ObterCategoriaIdAsync(id);
        if(categoria == null) 
                throw new ArgumentException("Categoria não encontrada");
        categoria.Ativar();

        await _repository.AtualizarCategoriaAsync(categoria);
    }
}
