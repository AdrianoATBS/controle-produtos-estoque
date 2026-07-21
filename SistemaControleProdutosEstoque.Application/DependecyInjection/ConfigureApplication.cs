using Microsoft.Extensions.DependencyInjection;
using SistemaControleProdutosEstoque.Application.UseCases;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.AlterarNomeCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.BuscarCategoriaPorIdUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.CriarProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Categoria.ListarTodasCategoria;
using SistemaControleProdutosEstoque.Application.UseCases.DesativarCategoriaUseCase;
using SistemaControleProdutosEstoque.Application.Validators.Categorias;

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
        return services;
    }
}
