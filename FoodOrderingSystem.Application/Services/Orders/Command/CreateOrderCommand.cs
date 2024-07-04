using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.Orders.Command;

public sealed record CreateOrderCommand(OrderDto OrderDto) : ICommand<FoodOrderingSystem.Core.Entities.Order>;

