namespace FoodOrderingSystem.Core.Entities;

public class Payment
{
    public Guid PaymentId { get; set; }
    public Guid OrderId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentStatus { get; set; }
}
