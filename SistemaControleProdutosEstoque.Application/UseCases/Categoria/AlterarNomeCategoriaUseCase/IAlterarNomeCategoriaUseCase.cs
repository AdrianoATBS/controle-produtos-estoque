using SistemaControleProdutosEstoque.Application.Requests.Categorias;
using SistemaControleProdutosEstoque.Application.Responses.Categorias;

namespace SistemaControleProdutosEstoque.Application.UseCases.Categoria.AlterarNomeCategoriaUseCase;

public interface IAlterarNomeCategoriaUseCase
{
    Task<AlterarNomeCategoriaResponse> Executar(Guid id, AlterarNomeCategoriaRequest request);
}
