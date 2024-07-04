using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodOrderingSystem.Core.Entities;

public class OrderItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string OrderId { get; set; }
    public string FoodItemId { get; set; }
    public string FoodName { get; set; }
    public int Quantity { get; set; }
    public decimal ItemPrice { get; set; }
}
