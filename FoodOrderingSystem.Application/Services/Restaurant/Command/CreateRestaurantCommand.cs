using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.Restaurant.Command;

public sealed record CreateRestaurantCommand(RestaurantDto RestaurantDto) : ICommand<FoodOrderingSystem.Core.Entities.Restaurant>;

