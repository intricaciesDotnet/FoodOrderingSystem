using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions.Interfaces;

public interface IFoodItemMongoDbContext
{
    IMongoCollection<FoodOrderingSystem.Core.Entities.FoodItem> FoodItems { get; set; }
}
