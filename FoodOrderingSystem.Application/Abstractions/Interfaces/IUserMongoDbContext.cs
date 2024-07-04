using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions.Interfaces;

public interface IUserMongoDbContext
{
    IMongoCollection<FoodOrderingSystem.Core.Entities.User> Users { get; set; }
}
