using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;
using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.Services.User.Command;

public sealed record CreateUserCommand(UserDto UserDto) : ICommand<FoodOrderingSystem.Core.Entities.User>;

