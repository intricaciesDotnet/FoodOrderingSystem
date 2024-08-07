﻿using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Command;
using FoodOrderingSystem.Application.Services.User.Query;
using FoodOrderingSystem.Application.Shared;
using FoodOrderingSystem.Persistence.Abstractions.Interfaces;
using MediatR;

namespace FoodOrderingSystem.Persistence.Services;

public sealed class UserService(ISender sender) : IUserService
{
    private readonly ISender Sender = sender;
    public async Task<IResult> AddAsync(UserDto userDto, CancellationToken cancellationToken)
    {
		try
		{
            UserDto validDto = userDto ?? throw new ArgumentNullException(nameof(userDto));

            CreateUserCommand command = new CreateUserCommand(userDto);

            Result<Core.Entities.User> userResult = await Sender.Send(command, cancellationToken);

            return userResult.IsSuccess ?
                userResult :
                Result<UserDto>.Failure(ErrorType.BadRequest);
        }
		catch (FoodOrderException ex)
		{
			return Result<UserDto>.Failure(ErrorType.BadRequest);
		}
    }

    public async Task<IResult> GetAllAsync(CancellationToken cancellationToken)
    {

        try
        {
            var command = new AllUserQuery();

            Result<IList<Core.Entities.User>> userListResult = await Sender.Send(command, cancellationToken);

            return userListResult.IsSuccess ?
                userListResult :
                Result<IList<Core.Entities.User>>.Failure(ErrorType.BadRequest);
        }
        catch (FoodOrderException ex)
        {
            return Result<IList<Core.Entities.User>>.Failure(ErrorType.BadRequest);
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

            GetUserByIdQuery command = new GetUserByIdQuery(id);

            Result<Core.Entities.User> userResult = await Sender.Send(command, cancellationToken);

            return userResult.IsSuccess ?
                userResult :
                Result<IList<Core.Entities.User>>.Failure(ErrorType.BadRequest);


        }
        catch (FoodOrderException ex)
        {
            return Result<IList<Core.Entities.User>>.Failure(ErrorType.BadRequest);
        }
    }

    public async Task<IResult> UpdateAsync(string Id, UserDto userDto, CancellationToken cancellationToken)
    {
        try
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new ArgumentNullException(nameof(Id));
            }

            UpdateUserCommand command = new UpdateUserCommand(Id, userDto);

            Result<Core.Entities.User> userResult = await Sender.Send(command, cancellationToken);

            return userResult.IsSuccess ?
                userResult :
                Result<Core.Entities.User>.Failure(ErrorType.BadRequest);

        }
        catch (FoodOrderException ex)
        {
            return Result<Core.Entities.User>.Failure(ErrorType.BadRequest);
        }
    }
}
