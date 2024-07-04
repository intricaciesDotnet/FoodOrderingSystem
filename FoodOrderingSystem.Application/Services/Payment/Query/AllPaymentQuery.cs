using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.Payment.Query;

public sealed record AllPaymentQuery : IQuery<IList<FoodOrderingSystem.Core.Entities.Payment>>;
