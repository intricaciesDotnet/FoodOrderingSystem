using FoodOrderingSystem.Application.Abstractions.Messagings.Command;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Services.Payment.Command;

public sealed record CreatePaymentCommand(PaymentDto PaymentDto) : ICommand<FoodOrderingSystem.Core.Entities.Payment>;

