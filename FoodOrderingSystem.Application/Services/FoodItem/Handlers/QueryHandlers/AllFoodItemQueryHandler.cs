using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.FoodItem.Handlers.QueryHandlers;

public sealed class AllFoodItemQueryHandler(IFoodItemMongoDbContext foodItem) : IQueryHandler<AllFoodItemsQuery,
    IList<FoodOrderingSystem.Core.Entities.FoodItem>>
{

    private readonly IFoodItemMongoDbContext _foodItem = foodItem;
    public async Task<Result<IList<Core.Entities.FoodItem>>> Handle(AllFoodItemsQuery request, CancellationToken cancellationToken)
    {
		try
		{
            AllFoodItemsQuery valid = request ?? throw new FoodOrderException(nameof(request));

            List<Core.Entities.FoodItem> list = await _foodItem
                .FoodItems
                .Find(_ => true)
                .ToListAsync(cancellationToken);

            if (list == null)
            {
                throw new FoodOrderException(nameof(list));
            }

            return Result<IList<Core.Entities.FoodItem>>.Success(list);

        }
		catch (FoodOrderException)
		{
			return Result<IList<Core.Entities.FoodItem>>.Failure(ErrorType.None);
		}
    }
}
