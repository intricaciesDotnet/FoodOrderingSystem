using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Command;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Application.Services.User.Handlers.CommandHandler;

public sealed class CreateUserCommandHandler(IUserMongoDbContext userMongo,
    IMapper mapper) : ICommandHandler<CreateUserCommand, FoodOrderingSystem.Core.Entities.User>
{
    private readonly IUserMongoDbContext _userMongoDbContext = userMongo;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<Core.Entities.User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateUserCommand userRequest = request ?? throw new NotImplementedException(nameof(request));

            Core.Entities.User mapped = _mapper.Map<Core.Entities.User>(userRequest.UserDto);

            await _userMongoDbContext.Users.InsertOneAsync(mapped);

            return Result<Core.Entities.User>.Success();
        }
        catch (UserNotCreatedException ex)
        {
            return Result<Core.Entities.User>.Failure(ErrorType.UnableToCreate);
        }
    }
}
