using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.Orders.Query;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.QueryHandlers;

internal class AllOrdersQueryHandler : IQueryHandler<AllOrdersQuery,
    IList<FoodOrderingSystem.Core.Entities.Order>>
{
    public Task<Result<IList<Order>>> Handle(AllOrdersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
