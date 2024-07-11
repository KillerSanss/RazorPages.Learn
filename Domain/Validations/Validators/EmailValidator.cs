using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация электронной почты
/// </summary>
public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator(string paramName)
    {
        RuleFor(e => e)
            .NotNull().WithMessage(string.Format(ErrorMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.EmptyError, paramName))
            .Matches(RegexPatterns.EmailPattern).WithMessage(ErrorMessages.EmailFormat);
    }
}