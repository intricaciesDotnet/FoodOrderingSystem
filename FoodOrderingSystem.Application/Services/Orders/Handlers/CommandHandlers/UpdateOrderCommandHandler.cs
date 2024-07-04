using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Services.Orders.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.CommandHandlers;

public sealed class UpdateOrderCommandHandler : ICommandHandler<CreateOrderCommand,
    FoodOrderingSystem.Core.Entities.Order>

{
    public Task<Result<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
