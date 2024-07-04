using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.Restaurant.Query;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.Restaurant.Handlers.QueryHandlers;

public sealed class GetRestaurantByIdQueryHandler : IQueryHandler<GetRestaurantByIdQuery,
    FoodOrderingSystem.Core.Entities.Restaurant>
{
    public Task<Result<Core.Entities.Restaurant>> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
