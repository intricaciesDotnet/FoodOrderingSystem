using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.FoodItem.Command;

public sealed record CreateFoodItemCommand(FoodItemDto FoodItemDto) : ICommand<FoodOrderingSystem.Core.Entities.FoodItem>;

