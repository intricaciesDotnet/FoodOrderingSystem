using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.Helpers;
using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class FoodItemMongoDbContext : BaseMongoDbContext , IFoodItemMongoDbContext
{
    public FoodItemMongoDbContext(IOptions<FoodOrderDatabaseSettings> options) : base(options)
    {
    }

    public IMongoCollection<FoodItem> FoodItems 
    {
        get
        {
            return _context.Get<FoodItem>();
        }
        set
        {
            if (value != null)
                this.FoodItems = value;
        }
    }
}
