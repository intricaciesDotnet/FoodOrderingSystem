using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.OrderItem.Command;

public sealed record CreateOrderItemCommand(OrderItemDto OrderItemDto) : ICommand<FoodOrderingSystem.Core.Entities.OrderItem>;

