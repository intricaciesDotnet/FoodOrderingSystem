namespace FoodOrderingSystem.Application.DTOs;

public sealed record PaymentDto(string OrderId,
   DateTime Date,
   decimal Amount,
   string Method,
   bool Status);

