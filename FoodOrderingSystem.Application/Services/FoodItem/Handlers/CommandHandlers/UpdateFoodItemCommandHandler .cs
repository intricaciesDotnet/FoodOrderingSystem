using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.FoodItem.Handlers.CommandHandlers;

public sealed class UpdateFoodItemCommandHandler(IFoodItemMongoDbContext foodItem,
    IMapper mapper) : ICommandHandler<UpdateFoodItemCommand,
    FoodOrderingSystem.Core.Entities.FoodItem>
{
    private readonly IFoodItemMongoDbContext _foodItem = foodItem;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Core.Entities.FoodItem>> Handle(UpdateFoodItemCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateFoodItemCommand valid = request ?? throw new InvalidDataException(nameof(request));

            Core.Entities.FoodItem mapped = _mapper.Map<Core.Entities.FoodItem>(foodItem);

            FilterDefinitionBuilder<Core.Entities.FoodItem> filter = new();

            ReplaceOneResult result = await _foodItem
                .FoodItems
                .ReplaceOneAsync(filter.Where(x => x.Id == valid.Id), mapped);

            if (result == null)
            {
                throw new FoodOrderException(nameof(result));
            }

            Core.Entities.FoodItem updatedFoodItem = await _foodItem
                .FoodItems
                .Find(x => x.Id == request.Id)
                .FirstOrDefaultAsync();

            if (updatedFoodItem == null)
            {
                throw new FoodOrderException(nameof(updatedFoodItem));
            }

            return Result<Core.Entities.FoodItem>.Success(updatedFoodItem);

        }
        catch (FoodOrderException)
        {
            return Result<Core.Entities.FoodItem>.Failure(ErrorType.UnableToCreate);
        }
    }
}
