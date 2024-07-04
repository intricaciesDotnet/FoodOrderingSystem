using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.Restaurant.Query;

public sealed record GetRestaurantByIdQuery(string Id): IQuery<FoodOrderingSystem.Core.Entities.Restaurant>;
