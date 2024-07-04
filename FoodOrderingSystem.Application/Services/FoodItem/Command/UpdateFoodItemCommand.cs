using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.FoodItem.Command;

public sealed record UpdateFoodItemCommand(string Id, FoodItemDto FoodItemDto) : ICommand<FoodOrderingSystem.Core.Entities.FoodItem>;

