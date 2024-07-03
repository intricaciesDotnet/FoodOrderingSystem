namespace FoodOrderingSystem.Core.Entities;

public class Restaurant
{
    public Guid RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<FoodItem> FoodItems { get; set; }
}
