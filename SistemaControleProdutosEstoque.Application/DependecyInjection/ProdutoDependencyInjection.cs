using Microsoft.Extensions.DependencyInjection;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutoPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutosPorCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.DeletarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ListarTodosOsProdutosUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ReativarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.Validators.Produtos;

namespace SistemaControleProdutosEstoque.Application.DependecyInjection;

public static class ProdutoDependencyInjection
{
    public static IServiceCollection ProdutoApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICriarProdutoUseCase, CriarProdutoUseCase>();
        services.AddScoped<CriarProdutoRequestValidator>();
        services.AddScoped<IAlterarProdutoUseCase, AlterarProdutoUseCase>();
        services.AddScoped<AlterarProdutoRequestValidator>();
        services.AddScoped<IBuscarProdutoPorIdUseCase, BuscarProdutoPorIdUseCase>();
        services.AddScoped<IListarTodosOsProdutosUseCase, ListarTodosOsProdutosUseCase>();
        services.AddScoped<IDesativarProdutoUseCase, DesativarProdutoUseCase>();
        services.AddScoped<IReativarProdutoUseCase, ReativarProdutoUseCase>();
        services.AddScoped<IDeletarProdutoUseCase, DeletarProdutoUseCase>();
        services.AddScoped<IBuscarProdutosPorCategoriaUseCase, BuscarProdutosPorCategoriaUseCase>();
        return services;
    }
}
