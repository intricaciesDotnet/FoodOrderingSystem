using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodOrderingSystem.Core.Entities;

public class FoodItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string FoodName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
