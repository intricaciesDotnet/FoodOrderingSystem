using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Command;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.FoodItem.Handlers.CommandHandlers;

public sealed class CreateFoodItemCommandHandler(IFoodItemMongoDbContext foodItem,
    IMapper mapper) : ICommandHandler<CreateFoodItemCommand,
    FoodOrderingSystem.Core.Entities.FoodItem>
{
    private readonly IFoodItemMongoDbContext _foodItem = foodItem;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Core.Entities.FoodItem>> Handle(CreateFoodItemCommand request, CancellationToken cancellationToken)
    {
		try
		{
            CreateFoodItemCommand valid = request ?? throw new InvalidDataException(nameof(request));

            Core.Entities.FoodItem mapped = _mapper.Map<Core.Entities.FoodItem>(request.FoodItemDto);

            await _foodItem.FoodItems.InsertOneAsync(mapped);

            Core.Entities.FoodItem result = await _foodItem
                .FoodItems
                .Find(x => x.Id == mapped.Id)
                .FirstOrDefaultAsync();

            if (result  == null)
            {
                throw new InvalidDataException(nameof(result));
            }

            return Result<Core.Entities.FoodItem>.Success(result);

        }
		catch (FoodOrderException ex)
		{
			return Result<Core.Entities.FoodItem>.Failure(ErrorType.UnableToCreate);
		}
    }
}
