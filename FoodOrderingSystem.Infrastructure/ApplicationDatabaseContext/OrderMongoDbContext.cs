using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.Helpers;
using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class OrderMongoDbContext : BaseMongoDbContext , IOrdersMongoDbContext
{
    public OrderMongoDbContext(IOptions<FoodOrderDatabaseSettings> options) : base(options)
    {
    }

    public IMongoCollection<Order> Orders
    {
        get
        {
            return _context.Get<Order>();
        }
        set
        {
            if (value != null)
                this.Orders = value;
        }
    }
}
