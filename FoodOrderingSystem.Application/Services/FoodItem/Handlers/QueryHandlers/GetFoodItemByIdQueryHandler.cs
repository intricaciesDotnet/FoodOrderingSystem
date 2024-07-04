using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.FoodItem.Handlers.QueryHandlers;

public sealed class GetFoodItemByIdQueryHandler(IFoodItemMongoDbContext foodItem) : IQueryHandler<GetFoodItemByIdQuery,
    FoodOrderingSystem.Core.Entities.FoodItem>
{
    private readonly IFoodItemMongoDbContext _foodItem = foodItem;
    public async Task<Result<Core.Entities.FoodItem>> Handle(GetFoodItemByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            GetFoodItemByIdQuery userRequest = request ?? throw new NotImplementedException(nameof(request));

            Core.Entities.FoodItem result = await _foodItem
                .FoodItems
                .Find(x => x.Id == userRequest.Id)
                .FirstOrDefaultAsync();

            return Result<Core.Entities.FoodItem>.Success(result);
        }
        catch (FoodOrderException ex)
        {
            return Result<Core.Entities.FoodItem>.Failure(ErrorType.UnableToCreate);
        }
    }
}
