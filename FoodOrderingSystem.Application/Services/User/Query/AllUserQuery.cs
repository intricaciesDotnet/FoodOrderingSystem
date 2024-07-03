using FoodOrderingSystem.Application.Abstractions.Messagings.Command;

namespace FoodOrderingSystem.Application.Services.User.Query;

public sealed record AllUserQuery : ICommand<IList<FoodOrderingSystem.Core.Entities.User>>;
