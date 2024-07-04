using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Services.OrderItem.Command;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.CommandHandlers;

public sealed class CreateOrderItemCommandHandler : ICommandHandler<CreateOrderItemCommand,
    FoodOrderingSystem.Core.Entities.OrderItem>
{
    public Task<Result<Core.Entities.OrderItem>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
