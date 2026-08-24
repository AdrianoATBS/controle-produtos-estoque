using Microsoft.Extensions.DependencyInjection;


namespace SistemaControleProdutosEstoque.Application.DependecyInjection;

public static class ConfigureApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.CategoriaApplicationServices();
        services.ProdutoApplicationServices();
        services.EstoqueApplicationServices();

        return services;
    }
}
