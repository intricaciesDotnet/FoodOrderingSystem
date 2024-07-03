using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Application.Shared;

namespace FoodOrderingSystem.Persistence.Abstractions.Interfaces;

public interface IUserService
{
    Task<IResult> AddUserAsync(UserDto userDto, CancellationToken cancellationToken);
    Task<IResult> GetAllUserAsync(CancellationToken cancellationToken);
    Task<IResult> GetUserByIdAsync(string id, CancellationToken cancellationToken);
    Task<IResult> UpdateUserAsync(UserDto userDto, CancellationToken cancellationToken);

}
