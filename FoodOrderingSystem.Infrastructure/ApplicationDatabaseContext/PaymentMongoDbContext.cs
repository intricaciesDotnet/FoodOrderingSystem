using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.Helpers;
using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class PaymentMongoDbContext : BaseMongoDbContext , IPaymentMongoDbContext
{
    public PaymentMongoDbContext(IConfigurationManager connectionName, IOptions<FoodOrderDatabaseSettings> options) : base(connectionName)
    {
    }

    public IMongoCollection<Payment> Payments
    {
        get
        {
            return _context.Get<Payment>();
        }
        set
        {
            if (value != null)
                this.Payments = value;
        }
    }
}
