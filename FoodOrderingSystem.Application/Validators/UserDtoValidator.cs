using FluentValidation;
using FoodOrderingSystem.Application.Constants;
using FoodOrderingSystem.Application.DTOs;

namespace FoodOrderingSystem.Application.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(Messages.NameValidator)
            .MinimumLength(Messages.MinLen)
            .MaximumLength(Messages.MaxLen);

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(Messages.EmailValidator)
            .Matches(RegexPatterns.Email)
            .WithMessage(Messages.InvalidEmailValidator);
            
    }
}
