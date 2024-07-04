using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.OrderItem.Query;

public sealed record GetOrderItemByIdQuery(string Id) : IQuery<FoodOrderingSystem.Core.Entities.OrderItem>;

