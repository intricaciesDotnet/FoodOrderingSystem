using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Command;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.User.Handlers.CommandHandler;

public sealed class UpdateUserCommandHandler(IUserMongoDbContext userMongo) : ICommandHandler<UpdateUserCommand, FoodOrderingSystem.Core.Entities.User>
{
    private readonly IUserMongoDbContext _userMongoDbContext = userMongo;
    public async Task<Result<Core.Entities.User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateUserCommand userRequest = request ?? throw new NotImplementedException(nameof(request));

            Core.Entities.User user = new()
            {
                Id = userRequest.Id,
                Name = userRequest.UserDto.Name,
                Email = userRequest.UserDto.Email,
                Password = userRequest.UserDto.Password,
                PhoneNumber = userRequest.UserDto.PhoneNumber,
                Addresses = userRequest.UserDto.Addresses
            };

            FilterDefinitionBuilder<Core.Entities.User> filter = new();

            await _userMongoDbContext.Users.ReplaceOneAsync(filter.Where(x => x.Id == userRequest.Id), user);

            Core.Entities.User result = await _userMongoDbContext
                .Users
                .Find(x => x.Id == userRequest.Id)
                .FirstOrDefaultAsync();

            return Result<Core.Entities.User>.Success(result);
        }
        catch (UserNotCreatedException ex)
        {
            return Result<Core.Entities.User>.Failure(ErrorType.UnableToCreate);
        }
    }
}
