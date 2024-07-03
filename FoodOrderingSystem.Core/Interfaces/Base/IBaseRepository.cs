using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Core.Interfaces.Base;

public interface IBaseRepository<TInput> where TInput : class
{
    Task<TInput> GetRestaurantByIdAsync(Guid id);

    Task<IEnumerable<TInput>> GetAllAsync();

    Task AddUserAsync(TInput user);
    Task UpdateUserAsync(TInput user);
    Task DeleteUserAsync(Guid userId);
}
