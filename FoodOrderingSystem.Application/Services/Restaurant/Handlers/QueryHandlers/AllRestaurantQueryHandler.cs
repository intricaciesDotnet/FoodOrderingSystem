using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Services.Restaurant.Query;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.Restaurant.Handlers.QueryHandlers;

public sealed class AllRestaurantQueryHandler : IQueryHandler<AllRestaurantQuery,
    IList<FoodOrderingSystem.Core.Entities.Restaurant>>
{
    public Task<Result<IList<Core.Entities.Restaurant>>> Handle(AllRestaurantQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
