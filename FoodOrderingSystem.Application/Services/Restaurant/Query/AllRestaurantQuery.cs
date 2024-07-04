using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.Restaurant.Query;

public sealed record AllRestaurantQuery : IQuery<IList<FoodOrderingSystem.Core.Entities.Restaurant>>;
