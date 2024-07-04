using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions.Interfaces;

public interface IOrderItemMongoDbContext
{
    IMongoCollection<FoodOrderingSystem.Core.Entities.OrderItem> OrderItems { get; set; }
}
