using FoodOrderingSystem.Core.Entities;

namespace FoodOrderingSystem.Application.DTOs;

public record UserDto(
    string Name,
    string Email,
    string Password,
    string PhoneNumber,
    List<string> Addresses);
