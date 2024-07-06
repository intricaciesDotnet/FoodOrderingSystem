using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class BaseMongoDbContext
{
   protected readonly IMongoDatabase _context;

    public BaseMongoDbContext(IConfigurationManager configuration, IOptions<FoodOrderDatabaseSettings> options = default)
    {
        if (options == null)
        {
            string name = configuration.GetConnectionString("MongoDb")!;
            string database = configuration.GetConnectionString("DatabaseName")!;
            _context = new MongoClient(name).GetDatabase(database);
        }
        else
        {
            //_context = new MongoClient(options.Value.MongoDb).GetDatabase("")
        }
    }
}
