using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.DTOs;

public sealed record OrderDto(string UserId,
    DateTime OrderDate,
    decimal TotalAmount,
    bool Status,
    List<OrderItem> OrderItems,
    Payment Payment);

