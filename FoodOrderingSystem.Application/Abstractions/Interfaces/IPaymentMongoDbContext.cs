using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Abstractions.Interfaces;

public interface IPaymentMongoDbContext
{
    IMongoCollection<FoodOrderingSystem.Core.Entities.Payment> Payments { get; set; }
}
