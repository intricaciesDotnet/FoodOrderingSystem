namespace FoodOrderingSystem.Application.DTOs;

public sealed record RestaurantDto(string Name,
   string Address,
   string PhoneNumber,
   string Email,
   List<FoodItemDto> FoodItemDtos);

