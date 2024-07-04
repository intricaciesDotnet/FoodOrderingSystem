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
            AllFoodItemsQuery valid = request ?? throw new ArgumentNullException(nameof(request));

            List<Core.Entities.FoodItem> list = await _foodItem
                .FoodItems
                .Find(_ => true)
                .ToListAsync(cancellationToken);

            if (list == null)
            {
                return Result<IList<Core.Entities.FoodItem>>.Failure(ErrorType.None);
            }

            return Result<IList<Core.Entities.FoodItem>>.Success(list);

        }
		catch (FoodOrderException ex)
		{
			return Result<IList<Core.Entities.FoodItem>>.Failure(ErrorType.None);
		}
    }
}
