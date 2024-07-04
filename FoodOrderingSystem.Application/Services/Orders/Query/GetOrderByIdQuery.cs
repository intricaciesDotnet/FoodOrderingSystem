using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.Orders.Query;

public sealed record GetOrderByIdQuery(string Id) : IQuery<FoodOrderingSystem.Core.Entities.Order>;

