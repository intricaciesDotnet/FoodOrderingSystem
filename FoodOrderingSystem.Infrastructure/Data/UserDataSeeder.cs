using FoodOrderingSystem.Core.Entities;
using FoodOrderingSystem.Infrastructure.ApplicationDatabaseContext;
using MongoDB.Driver;

namespace FoodOrderingSystem.Infrastructure.Data;

public class UserDataSeeder
{
    private MangoDbContext _dbContext;
    private IMongoCollection<User> _users;

    public UserDataSeeder(MangoDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = _dbContext.Users;
    }

    public async Task SeedData()
    {
        await SeedUsersAsync();
    }

    private async Task SeedUsersAsync()
    {
        if (await _users.CountDocumentsAsync(FilterDefinition<User>.Empty) == 0)
        {
            var users = new List<User>
                {
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        Password = "hashed_password",
                        PhoneNumber = "123-456-7890",
                        Addresses = new()
                        {
                            "123 Main St, City, Country"
                        }
                    },
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Jane Smith",
                        Email = "jane.smith@example.com",
                        Password = "hashed_password",
                        PhoneNumber = "987-654-3210",
                        Addresses = new() 
                        {
                            "456 Another St, City, Country" 
                        }
                    }
                };

            await _users.InsertManyAsync(users);
        }
    }
}
