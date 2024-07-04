using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.FoodItem.Query;

public sealed record GetFoodItemByIdQuery(string Id) : IQuery<FoodOrderingSystem.Core.Entities.FoodItem>;

