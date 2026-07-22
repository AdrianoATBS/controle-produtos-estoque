using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Domain.Interfaces;

public interface ICategoriaRepository
{
   
    Task AdicionarCategoriaAsync(Categoria categoria);
    Task AtualizarCategoriaAsync(Categoria categoria);
    Task DeletarCategoriaAsync(Guid id);
   
    Task<IEnumerable<Categoria>> ObterTodasCategoriasAsync();
    Task<Categoria?> ObterCategoriaIdAsync(Guid id);
    Task<bool> ExisteCategoriaComNomeAsync(string nome);

}
