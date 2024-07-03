using FoodOrderingSystem.Application.Abstractions;
using FoodOrderingSystem.Core.Entities;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class MangoDbContext(string connecitionName, string databaseName) : IMongoDbContext
{
    private readonly IMongoDatabase _context = new MongoClient(connecitionName)
        .GetDatabase(databaseName);

    public IMongoCollection<User> Users
    {
        get
        {
            return _context.Get<User>();
        }
        set
        {
            if (value != null)
            {
                this.Users = value;
            }
        }
    }

}




public static class GetTables
{

    public static IMongoCollection<TInput> Get<TInput>(this IMongoDatabase mongoDatabase) where TInput : class
    {
        return mongoDatabase.GetCollection<TInput>(typeof(TInput).Name);
    }

}
