using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class BaseMongoDbContext(IOptions<FoodOrderDatabaseSettings> options)
{
    protected readonly IMongoDatabase _context = new MongoClient(options.Value.MongoDb)
        .GetDatabase(options.Value.DatabaseName);
}
