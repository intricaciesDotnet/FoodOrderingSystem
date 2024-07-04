using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.OrderItem.Query;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.OrderItem.Handlers.QueryHandlers;

public sealed class GetOrderItemsByIdQueryHandler : IQueryHandler<GetOrderItemByIdQuery,
    FoodOrderingSystem.Core.Entities.OrderItem>
{
    public Task<Result<Core.Entities.OrderItem>> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
