using AutoMapper;
using FoodOrderingSystem.Application.Abstractions.Externals;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Command;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.User.Handlers.CommandHandler;

public sealed class CreateUserCommandHandler(IUserMongoDbContext userMongo,
    IMapper mapper, IGeoService geoService) : ICommandHandler<CreateUserCommand, FoodOrderingSystem.Core.Entities.User>
{
    private readonly IUserMongoDbContext _userMongoDbContext = userMongo;
    private readonly IMapper _mapper = mapper;
    private readonly IGeoService _geoService = geoService;
    public async Task<Result<Core.Entities.User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateUserCommand userRequest = request ?? throw new NotImplementedException(nameof(request));

            Core.Entities.User mapped = _mapper.Map<Core.Entities.User>(userRequest.UserDto);

            Core.Entities.Address location =  await _geoService.GetLocationAsync();

            mapped.GeoLocation = location;

            await _userMongoDbContext.Users.InsertOneAsync(mapped);

            Core.Entities.User _user = await _userMongoDbContext
                .Users
                .Find(x => x.Id == mapped.Id)
                .FirstOrDefaultAsync();

            if (_user == null)
            {
                throw new FoodOrderException(nameof(_user));
            }

            return Result<Core.Entities.User>.Success(_user);
        }
        catch (FoodOrderException ex)
        {
            return Result<Core.Entities.User>.Failure(ErrorType.UnableToCreate);
        }
    }
}
