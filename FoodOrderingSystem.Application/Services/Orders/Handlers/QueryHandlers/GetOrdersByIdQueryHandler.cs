using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.Orders.Query;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.Services.Orders.Handlers.QueryHandlers;

internal class GetOrdersByIdQueryHandler : IQueryHandler<GetOrderByIdQuery,
    FoodOrderingSystem.Core.Entities.Order>
{
    public Task<Result<Order>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
