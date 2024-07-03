using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using FoodOrderingSystem.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderingSystem.Persistence.ServiceRegisterations;

public static class Peristence
{
    public static IServiceCollection AddPresistenceLayer(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        return services;
    }
}
