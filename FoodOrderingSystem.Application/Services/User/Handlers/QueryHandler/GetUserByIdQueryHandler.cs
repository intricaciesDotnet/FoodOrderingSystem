using FoodOrderingSystem.Application.Abstractions;
using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.User.Handlers.QueryHandler;

public sealed class GetUserByIdQueryHandle(IUserMongoDbContext userMongo) : IQueryHandler<GetUserByIdQuery,
    FoodOrderingSystem.Core.Entities.User>
{
    private readonly IUserMongoDbContext _userMongoDbContext = userMongo;
    public async Task<Result<Core.Entities.User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            GetUserByIdQuery validRequest = request ?? throw new ArgumentNullException(nameof(request));

            Core.Entities.User user = await _userMongoDbContext
                .Users
                .Find(x => x.Id == validRequest.Id)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Result<Core.Entities.User>.Success(user);

        }
        catch (UserNotCreatedException ex)
        {
            return Result<Core.Entities.User>.Failure(ErrorType.BadRequest);
        }
    }
}


