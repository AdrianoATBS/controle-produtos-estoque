using SistemaControleProdutosEstoque.Domain.Entities;

namespace SistemaControleProdutosEstoque.Domain.Interfaces;

public interface ICategoriaRepository
{
    void AdicionarCategoria(Categoria categoria);
    void AtualizarCategoria(Categoria categoria);
    void DeletarCategoria(Guid id);
   
    Task<IEnumerable<Categoria>> ObterTodasCategoriasAsync();
    Categoria? ObterCategoriaId(Guid id);
    bool ExisteCategoriaComNome(string nome);

}
