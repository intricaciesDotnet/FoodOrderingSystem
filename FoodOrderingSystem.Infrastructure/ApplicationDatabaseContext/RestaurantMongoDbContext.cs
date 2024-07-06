using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.Helpers;
using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class RestaurantMongoDbContext : BaseMongoDbContext , IRestaurantMongoDbContext
{
    public RestaurantMongoDbContext(IConfigurationManager connectionName, IOptions<FoodOrderDatabaseSettings> options) : base(connectionName)
    {
    }

    public IMongoCollection<Restaurant> Restaurants
    {
        get
        {
            return _context.Get<Restaurant>();
        }
        set
        {
            if (value != null)
                this.Restaurants = value;
        }
    }
}
