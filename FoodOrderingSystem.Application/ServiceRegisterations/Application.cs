using FluentValidation;
using FluentValidation.AspNetCore;
using FoodOrderingSystem.Application.Abstractions.Externals;
using FoodOrderingSystem.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrderingSystem.Application.ServiceRegisterations;

public static class Application
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var assembly = typeof(Application).Assembly;
        services.AddMediatR(opt => 
            opt.RegisterServicesFromAssembly(assembly));

        services.AddAutoMapper(typeof(Application));

        services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();

        services.AddHttpClient();

        services.AddTransient<IGeoService, GeoService>();

        return services;
    }
}
