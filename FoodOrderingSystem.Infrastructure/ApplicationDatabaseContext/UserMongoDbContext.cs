using FoodOrderingSystem.Application.Abstractions.Interfaces;
using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.Helpers;
using FoodOrderingSystem.Infrastructure.Modals;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;

public class UserMongoDbContext : BaseMongoDbContext , IUserMongoDbContext
{
    public UserMongoDbContext(IOptions<FoodOrderDatabaseSettings> options) : base(options)
    {
    }

    public IMongoCollection<User> Users
    {
        get
        {
            return _context.Get<User>();
        }
        set
        {
            if (value != null)
                this.Users = value;
        }
    }
}
