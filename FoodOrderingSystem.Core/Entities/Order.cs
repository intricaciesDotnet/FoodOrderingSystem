namespace FoodOrderingSystem.Core.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public Payment Payment { get; set; }
}
