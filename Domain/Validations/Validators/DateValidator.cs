using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация даты
/// </summary>
public class DateValidator : AbstractValidator<DateTime>
{
    public DateValidator(string paramName)
    {
        RuleFor(d => d)
            .NotEmpty().WithMessage(string.Format(ErrorMessages.EmptyError, paramName))
            .LessThan(DateTime.Now).WithMessage(string.Format(ErrorMessages.FutureDate, paramName));
    }
}