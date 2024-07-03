using FoodOrderingSystem.Application.Abstractions;
using FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderingSystem.Infrastructure.ServiceRegisterations;

public static class Infrastructure
{
    private readonly static string Name = "MongoDB";
    private readonly static string DatabaseName = "FoodOrderingDb";
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
         IConfigurationManager configuration)
    {
        services.AddScoped<IMongoDbContext, MangoDbContext>(
            sp => new MangoDbContext(configuration.GetConnectionString(Name)!, DatabaseName));

        return services;
    }
}
