using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.Helpers;
using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class OrderItemMongoDbContext : BaseMongoDbContext , IOrderItemMongoDbContext
{
    public OrderItemMongoDbContext(IConfigurationManager connectionName, IOptions<FoodOrderDatabaseSettings> options) : base(connectionName)
    {
    }

    public IMongoCollection<OrderItem> OrderItems 
    {
        get
        {
            return _context.Get<OrderItem>();
        }
        set
        {
            if (value != null)
                this.OrderItems = value;
        }
    }
}
