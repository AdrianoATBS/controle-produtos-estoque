using Microsoft.Extensions.DependencyInjection;
using SistemaControleProdutosEstoque.Application.UseCases;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.AlterarNomeCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.DeletarCategoria;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.DesativarCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.ListarTodasCategoria;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.ReativarCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.AlterarNomeDoProduto;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.BuscarProdutoPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.DeletarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.DesativarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ListarTodosOsProdutosUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Produtos.ReativarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.Validators.Categorias;
using SistemaControleProdutosEstoque.Application.Validators.Produtos;

namespace SistemaControleProdutosEstoque.Application.DependecyInjection;

public static class ConfigureApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CriarCategoriaRequestValidator>();
        services.AddScoped<ICriarCategoriaUseCase, CriarCategoriaUseCase>();
        services.AddScoped<AlterarNomeCategoriaRequestValidator>();
        services.AddScoped<IAlterarNomeCategoriaUseCase, AlterarNomeCategoriaUseCase>();
        services.AddScoped<IBuscarCategoriaPorIdUseCase, BuscarCategoriaPorIdUseCase>();
        services.AddScoped<IListaTodasCategoriaUseCase, ListaTodasCategoriaUseCase>();
        services.AddScoped<IDesativarCategoriaUseCase, DesativarCategoriaUseCase>();
        services.AddScoped<IReativarCategoriaUseCase, ReativarCategoriaUseCase>();
        services.AddScoped<IDeletarCategoriaUseCase, DeletarCategoriaUseCase>();

        services.AddScoped<ICriarProdutoUseCase, CriarProdutoUseCase>();
        services.AddScoped<CriarProdutoRequestValidator>();
        services.AddScoped<IAlterarProdutoUseCase, AlterarProdutoUseCase>();
        services.AddScoped<AlterarProdutoRequestValidator>();
        services.AddScoped<IBuscarProdutoPorIdUseCase, BuscarProdutoPorIdUseCase>();
        services.AddScoped<IListarTodosOsProdutosUseCase, ListarTodosOsProdutosUseCase>();
        services.AddScoped<IDesativarProdutoUseCase, DesativarProdutoUseCase>();
        services.AddScoped<IReativarProdutoUseCase, ReativarProdutoUseCase>();
        services.AddScoped<IDeletarProdutoUseCase, DeletarProdutoUseCase>();
        return services;
    }
}
