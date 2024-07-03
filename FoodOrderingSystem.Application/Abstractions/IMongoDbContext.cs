using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions;

public interface IMongoDbContext
{
    IMongoCollection<User> Users { get; set; }
}
