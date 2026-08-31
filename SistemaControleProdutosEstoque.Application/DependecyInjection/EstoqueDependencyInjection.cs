using Microsoft.Extensions.DependencyInjection;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.AdicionarEstoqueUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarMovimentacaoPorProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarTodasMovimentacoesUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.BuscarUltimaMovimentacaoDoProdutoUseCase;
using SistemaControleProdutosEstoque.Application.UseCases.Estoque.FiltrarPorPeriodoUseCase;
using SistemaControleProdutosEstoque.Application.Validators.Estoque;

namespace SistemaControleProdutosEstoque.Application.DependecyInjection;

public static class EstoqueDependencyInjection
{
    public static IServiceCollection EstoqueApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAdicionarEstoqueUseCase, AdicionarEstoqueUseCase>();
        services.AddScoped<AdicionarEstoqueRequestValidator>();
        services.AddScoped<IBuscarMovimentacaoPorProdutoUseCase, BuscarMovimentacaoPorProdutoUseCase>();
        services.AddScoped<IBuscarUltimaMovimentacaoDoProdutoUseCase, BuscarUltimaMovimentacaoDoProdutoUseCase>();
        services.AddScoped<IBuscarTodasMovimentacoesUseCase, BuscarTodasMovimentacoesUseCase>();
        services.AddScoped<IFiltrarPorPeriodoUseCase, FiltrarPorPeriodoUseCase>();
        services.AddScoped<FiltrarPorPeriodoRequestValidator>();


        return services;
    }
}
