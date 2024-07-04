using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodOrderingSystem.Core.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public bool Status { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public Payment Payment { get; set; }
}
