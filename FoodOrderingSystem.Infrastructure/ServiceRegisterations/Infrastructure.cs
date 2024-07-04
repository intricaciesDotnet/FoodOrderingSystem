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
       
        services.AddScoped<BaseMongoDbContext>();
        services.AddScoped<IFoodItemMongoDbContext, FoodItemMongoDbContext>();
        services.AddScoped<IOrderItemMongoDbContext, OrderItemMongoDbContext>();
        services.AddScoped<IOrdersMongoDbContext, OrderMongoDbContext>();
        services.AddScoped<IPaymentMongoDbContext, PaymentMongoDbContext>();
        services.AddScoped<IRestaurantMongoDbContext, RestaurantMongoDbContext>();
        services.AddScoped<IUserMongoDbContext, UserMongoDbContext>();

        return services;
    }
}
