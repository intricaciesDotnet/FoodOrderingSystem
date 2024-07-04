namespace FoodOrderingSystem.Application.DTOs;

public sealed record OrderItemDto(string OrderId,
    string FoodItemId,
    string FoodName,
    int Quantity,
    decimal ItemPrice);

