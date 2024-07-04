using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions.Interfaces;

public interface IOrdersMongoDbContext
{
    IMongoCollection<FoodOrderingSystem.Core.Entities.Order> Orders { get; set; }
}
