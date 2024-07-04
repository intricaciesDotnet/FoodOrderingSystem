using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.Abstractions.Externals;

public interface IGeoService
{
    Task<Address> GetLocationAsync();
}
