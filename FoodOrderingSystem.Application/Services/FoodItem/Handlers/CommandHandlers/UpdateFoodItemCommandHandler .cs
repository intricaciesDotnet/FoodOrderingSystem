using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Command;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.FoodItem.Handlers.CommandHandlers;

public sealed class UpdateFoodItemCommandHandler(IFoodItemMongoDbContext foodItem) : ICommandHandler<UpdateFoodItemCommand,
    FoodOrderingSystem.Core.Entities.FoodItem>
{
    private readonly IFoodItemMongoDbContext _foodItem = foodItem;
    public async Task<Result<Core.Entities.FoodItem>> Handle(UpdateFoodItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateFoodItemCommand valid = request ?? throw new InvalidDataException(nameof(request));

            Core.Entities.FoodItem foodItem = new()
            {
                RestaurantId = valid.FoodItemDto.RestaurantId,
                RestaurantName = valid.FoodItemDto.RestaurantName,
                FoodName = valid.FoodItemDto.FoodName,
                Description = valid.FoodItemDto.Description, 
                Price = valid.FoodItemDto.Price,
            };

            FilterDefinitionBuilder<Core.Entities.FoodItem> filter = new();
            ReplaceOneResult result = await _foodItem
                .FoodItems
                .ReplaceOneAsync(filter.Where(x => x.Id == valid.Id), foodItem);

            return Result<Core.Entities.FoodItem>.Success(foodItem);

        }
        catch (FoodOrderException ex)
        {
            return Result<Core.Entities.FoodItem>.Failure(ErrorType.UnableToCreate);
        }
    }
}
