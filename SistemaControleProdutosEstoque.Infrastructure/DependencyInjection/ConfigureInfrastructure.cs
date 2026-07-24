using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SistemaControleProdutosEstoque.Domain.Interfaces;
using SistemaControleProdutosEstoque.Infrastructure.Data;
using SistemaControleProdutosEstoque.Infrastructure.Repositories;

namespace SistemaControleProdutosEstoque.Infrastructure.DependencyInjection;

public static class ConfigureInfrastructure
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
       services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        return services;
    }
}
