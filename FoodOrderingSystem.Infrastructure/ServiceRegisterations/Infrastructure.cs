using FoodOrderingSystem.Application.Abstractions;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderingSystem.Infrastructure.ServiceRegisterations;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
         IConfigurationManager configuration)
    {
        services.AddScoped<BaseMongoDbContext>(_ => new(configuration));
        services.AddScoped<IFoodItemMongoDbContext, FoodItemMongoDbContext>(_ => new(configuration,null!));
        services.AddScoped<IOrderItemMongoDbContext, OrderItemMongoDbContext>(_ => new(configuration, null!));
        services.AddScoped<IOrdersMongoDbContext, OrderMongoDbContext>(_ => new(configuration, null!));
        services.AddScoped<IPaymentMongoDbContext, PaymentMongoDbContext>(_ => new(configuration, null!));
        services.AddScoped<IRestaurantMongoDbContext, RestaurantMongoDbContext>(_ => new(configuration, null!));
        services.AddScoped<IUserMongoDbContext, UserMongoDbContext>(_ => new(configuration, null!));

        return services;
    }
}
