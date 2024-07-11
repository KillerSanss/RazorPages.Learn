using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация опыта работы
/// </summary>
public class WorkExperienceValidator : AbstractValidator<int>
{
    public WorkExperienceValidator(string paramName)
    {
        RuleFor(p => p)
            .NotNull().WithMessage(string.Format(ErrorMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ErrorMessages.EmptyError, paramName))
            .GreaterThan(0);
    }
}