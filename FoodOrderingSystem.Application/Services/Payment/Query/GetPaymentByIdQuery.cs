using FoodOrderingSystem.Application.Abstractions.Messagings.Query;

namespace FoodOrderingSystem.Application.Services.Payment.Query;

public sealed record GetPaymentByIdQuery(string Id) : IQuery<FoodOrderingSystem.Core.Entities.Payment>;
