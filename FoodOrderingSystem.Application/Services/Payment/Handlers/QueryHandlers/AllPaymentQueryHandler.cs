using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.Payment.Query;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.Payment.Handlers.QueryHandlers;

public sealed class AllPaymentQueryHandler : IQueryHandler<AllPaymentQuery,
    IList<FoodOrderingSystem.Core.Entities.Payment>>
{
    public Task<Result<IList<Core.Entities.Payment>>> Handle(AllPaymentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
