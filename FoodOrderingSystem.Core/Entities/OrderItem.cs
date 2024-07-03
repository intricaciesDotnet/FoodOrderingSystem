namespace FoodOrderingSystem.Core.Entities;

public class OrderItem
{
    public Guid OrderItemId { get; set; }
    public Guid OrderId { get; set; }
    public Guid FoodItemId { get; set; }
    public string FoodName { get; set; }
    public int Quantity { get; set; }
    public decimal ItemPrice { get; set; }
}
