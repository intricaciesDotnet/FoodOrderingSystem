using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions.Interfaces;

public interface IRestaurantMongoDbContext
{
    IMongoCollection<FoodOrderingSystem.Core.Entities.Restaurant> Restaurants { get; set; }
}
