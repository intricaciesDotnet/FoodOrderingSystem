using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.User.Handlers.QueryHandler;

public sealed class AllUserQueryHandler(IUserMongoDbContext userMongo) : IQueryHandler<AllUserQuery,
    IList<FoodOrderingSystem.Core.Entities.User>>
{

    private readonly IUserMongoDbContext _userMongo = userMongo;
    public async Task<Result<IList<Core.Entities.User>>> Handle(AllUserQuery request, CancellationToken cancellationToken)
    {
        try
        {
            List<Core.Entities.User> list = await _userMongo.Users
                .Find(_ => true).ToListAsync()!
                ?? throw new UserException(ErrorType.Invalid.ToString());

            return Result<IList<Core.Entities.User>>.Success(list);

        }
        catch (UserNotCreatedException)
        {
            return Result<IList<Core.Entities.User>>.Failure(ErrorType.BadRequest);
        }
    }
}


