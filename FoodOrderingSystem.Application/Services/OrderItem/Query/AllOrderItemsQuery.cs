using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.OrderItem.Query;

public sealed record AllOrderItemsQuery : IQuery<IList<FoodOrderingSystem.Core.Entities.OrderItem>>;

