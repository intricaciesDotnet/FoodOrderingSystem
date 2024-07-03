using FoodOrderingSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderingSystem.Application.ServiceRegisterations;

public static class Application
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var assembly = typeof(Application).Assembly;
        services.AddMediatR(opt => 
            opt.RegisterServicesFromAssembly(assembly));


        return services;
    }
}
