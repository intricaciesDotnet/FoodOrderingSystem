using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.Payment.Query;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.Payment.Handlers.QueryHandlers;

public sealed class GetPaymentByIdQueryHandler : IQueryHandler<GetPaymentByIdQuery,
    FoodOrderingSystem.Core.Entities.Payment>
{
    public Task<Result<Core.Entities.Payment>> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
