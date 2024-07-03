using FoodOrderingSystem.Application.Abstractions;
using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Exceptions;
using FoodOrderingSystem.Application.Services.User.Query;
using FoodOrderingSystem.Application.Shared;
using MongoDB.Driver;

namespace FoodOrderingSystem.Application.Services.User.Handler;

public sealed class AllUserQueryHandler(IMongoDbContext mongoDbContext) : ICommandHandler<AllUserQuery, 
    IList<FoodOrderingSystem.Core.Entities.User>>
{
    private readonly IMongoDbContext _mongoDbContext = mongoDbContext;
    public async Task<Result<IList<Core.Entities.User>>> Handle(AllUserQuery request, CancellationToken cancellationToken)
    {
        try
        {
            List<Core.Entities.User> list = await _mongoDbContext?.Users.Find(_ => true).ToListAsync()!
                ?? throw new UserException(ErrorType.Invalid.ToString());

            return Result<IList<Core.Entities.User>>.Success(list);
            
        }
        catch (UserNotCreatedException ex)
        {
            return Result<IList<Core.Entities.User>>.Failure(ErrorType.BadRequest);
        }
    }
}
