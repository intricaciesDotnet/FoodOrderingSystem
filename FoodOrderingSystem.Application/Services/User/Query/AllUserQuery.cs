using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.User.Query;

public sealed record AllUserQuery : IQuery<IList<FoodOrderingSystem.Core.Entities.User>>;
