using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Services.Payment.Command;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.Payment.Handlers.CommandHandlers;

public sealed class CreatePaymentCommandHandler : ICommandHandler<CreatePaymentCommand,
    FoodOrderingSystem.Core.Entities.Payment>
{
    public Task<Result<Core.Entities.Payment>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
