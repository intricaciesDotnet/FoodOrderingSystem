﻿using FoodOrderingSystem.Application.Abstractions;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Command;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.User.Handler;

public sealed class CreateUserCommandHandler(IMongoDbContext mongoDbContext) : ICommandHandler<CreateUserCommand,
    FoodOrderingSystem.Core.Entities.User>
{
    private readonly IMongoDbContext _mongoDbContext = mongoDbContext;
    public async Task<Result<Core.Entities.User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
		try
		{
            CreateUserCommand userRequest = request ?? throw new NotImplementedException(nameof(request));

            Core.Entities.User user = new()
            {
                Name = userRequest.UserDto.Name,
                Email = userRequest.UserDto.Email,
                Password = userRequest.UserDto.Password,
                PhoneNumber = userRequest.UserDto.PhoneNumber,
                Addresses = userRequest.UserDto.Addresses
            };

            await _mongoDbContext.Users.InsertOneAsync(user);

            return Result<Core.Entities.User>.Success();
        }
		catch (UserNotCreatedException ex)
		{
            return Result<Core.Entities.User>.Failure(ErrorType.UnableToCreate);
		}
        
    }
}
