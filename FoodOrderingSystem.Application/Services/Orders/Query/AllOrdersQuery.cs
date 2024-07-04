using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.Orders.Query;

public sealed record AllOrdersQuery : IQuery<IList<FoodOrderingSystem.Core.Entities.Order>>;

