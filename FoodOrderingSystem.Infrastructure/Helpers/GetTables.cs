using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.Helpers;

public static class GetTables
{
    public static IMongoCollection<TInput> Get<TInput>(this IMongoDatabase mongoDatabase) where TInput : class
    {
        return mongoDatabase.GetCollection<TInput>(typeof(TInput).Name);
    }
}
