using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FoodOrderingSystem.Core.Entities;

public class Payment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string OrderId { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string  Method { get; set; }
    public bool Status { get; set; }
}
