using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Services.Restaurant.Command;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.Restaurant.Handlers.CommandHandlers;

public sealed class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand,
    FoodOrderingSystem.Core.Entities.Restaurant>
{
    public Task<Result<Core.Entities.Restaurant>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
