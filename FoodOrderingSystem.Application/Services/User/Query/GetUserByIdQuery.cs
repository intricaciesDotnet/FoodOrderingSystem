using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.User.Query;

public record GetUserByIdQuery(string Id) : IQuery<FoodOrderingSystem.Core.Entities.User>;

