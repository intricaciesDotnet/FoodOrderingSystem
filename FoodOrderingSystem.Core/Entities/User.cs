using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FoodOrderingSystem.Core.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Addresses { get; set; }
    public Address GeoLocation { get; set; }
}
