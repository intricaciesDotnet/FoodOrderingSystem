using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.OrderItem.Query;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.QueryHandlers;

public sealed class AllOrderItemsQueryHandler : IQueryHandler<AllOrderItemsQuery,
    IList<FoodOrderingSystem.Core.Entities.OrderItem>>
{
    public Task<Result<IList<Core.Entities.OrderItem>>> Handle(AllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
