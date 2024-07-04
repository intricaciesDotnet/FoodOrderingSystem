using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.Restaurant.Command;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using MediatR;

namespace FoodOrderingSystem.Persistence.Services;

public sealed class RestaurantService : BaseAbstractService, IRestaurantService
{
    public RestaurantService(ISender sender) : base(sender)
    {
    }

    public async Task<IResult> AddAsync(RestaurantDto inputValue, CancellationToken cancellationToken)
    {
        try
        {
            RestaurantDto validDto = inputValue ?? throw new ArgumentNullException(nameof(inputValue));

            CreateRestaurantCommand command = new CreateRestaurantCommand(inputValue);

            Result<Restaurant> restaurantResult = await Sender.Send(command, cancellationToken);

            return restaurantResult.IsSuccess ?
                restaurantResult :
                Result<Restaurant>.Failure(ErrorType.BadRequest);
        }
        catch (UserNotCreatedException ex)
        {
            return Result<Restaurant>.Failure(ErrorType.BadRequest);
        }
    }

    public Task<IResult> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(string id, RestaurantDto inputValue, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
