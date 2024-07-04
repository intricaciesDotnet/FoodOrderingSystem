using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using FoodOrderingSystem.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderingSystem.Persistence.ServiceRegisterations;

public static class Peristence
{
    public static IServiceCollection AddPresistenceLayer(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IFoodItemService, FoodItemService>();
        services.AddTransient<IOrderItemService, OrderItemService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IRestaurantService, RestaurantService>();
        return services;
    }
}
