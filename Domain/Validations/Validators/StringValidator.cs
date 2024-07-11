using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация строк
/// </summary>
public class StringValidator  : AbstractValidator<string>
{
    public StringValidator(string paramName)
    {
        RuleFor(p => p)
            .NotNull().WithMessage(string.Format(ErrorMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.EmptyError, paramName))
            .Matches(RegexPatterns.LettersPattern).WithMessage(ErrorMessages.OnlyLetters);
    }
}