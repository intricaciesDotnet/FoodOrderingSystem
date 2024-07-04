using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.FoodItem.Query;

public sealed record AllFoodItemsQuery: IQuery<IList<FoodOrderingSystem.Core.Entities.FoodItem>>;

