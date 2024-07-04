using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.User.Command;

public record UpdateUserCommand(string Id, UserDto UserDto) : ICommand<FoodOrderingSystem.Core.Entities.User>;

