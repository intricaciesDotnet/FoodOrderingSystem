namespace FoodOrderingSystem.Core.Entities;

public class FoodItem
{
    public Guid FoodItemId { get; set; }
    public Guid RestaurantId { get; set; }
    public string FoodName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
