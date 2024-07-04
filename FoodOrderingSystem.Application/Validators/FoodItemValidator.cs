using FluentValidation;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Validators;

public class FoodItemValidator : AbstractValidator<FoodItemDto>
{
    public FoodItemValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be positive");
    }
}
