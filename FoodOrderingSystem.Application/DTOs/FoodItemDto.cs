namespace FoodOrderingSystem.Application.DTOs;

public sealed record FoodItemDto(string RestaurantId,
    string RestaurantName,
    string FoodName,
    string Description,
    decimal Price);

