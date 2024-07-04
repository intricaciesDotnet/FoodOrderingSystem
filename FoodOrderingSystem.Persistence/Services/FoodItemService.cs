using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.FoodItem.Command;
using FoodOrderingSystem.Application.Services.FoodItem.Query;
using FoodOrderingSystem.Application.Services.User.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using MediatR;
using System.Reflection;

namespace FoodOrderingSystem.Persistence.Services;

public sealed class FoodItemService : BaseAbstractService , IFoodItemService
{
    public FoodItemService(ISender sender) : base(sender)
    {
    }

    public async Task<IResult> AddAsync(FoodItemDto inputValue, CancellationToken cancellationToken)
    {
        try
        {
            FoodItemDto validDto = inputValue ?? throw new ArgumentNullException(nameof(inputValue));

            CreateFoodItemCommand command = new CreateFoodItemCommand(inputValue);

            Result<FoodItem> userResult = await Sender.Send(command, cancellationToken);

            return userResult.IsSuccess ?
                userResult :
                Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
        catch (UserNotCreatedException ex)
        {
            return Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
    }

    public async Task<IResult> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            Result<IList<FoodItem>> allFoodItems = await Sender.Send(new AllFoodItemsQuery(), cancellationToken);
            return allFoodItems.IsSuccess ?
                allFoodItems :
                Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
        catch (Exception)
        {

            return Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
    }

    public async Task<IResult> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            GetFoodItemByIdQuery command = new GetFoodItemByIdQuery(id);
            Result<FoodItem> byIdUserResult = await Sender.Send(command, cancellationToken);

            return byIdUserResult.IsSuccess ?
                byIdUserResult :
                Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
        catch (Exception)
        {
            return Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
    }

    public async Task<IResult> UpdateAsync(string id, FoodItemDto inputValue, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(id) && inputValue is { })
            {
                throw new ArgumentNullException(nameof(id) + nameof(inputValue));
            }

            UpdateFoodItemCommand command = new UpdateFoodItemCommand(id, inputValue!);
            Result<FoodItem> byIdUserResult = await Sender.Send(command, cancellationToken);

            return byIdUserResult.IsSuccess ?
                byIdUserResult :
                Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
        catch (Exception)
        {
            return Result<FoodItem>.Failure(ErrorType.BadRequest);
        }
    }
}
