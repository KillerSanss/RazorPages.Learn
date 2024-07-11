using FluentValidation;

namespace Domain.Validations;

/// <summary>
/// Класс расширение для валидаций
/// </summary>
public static class ValidateExtension
{
    public static T ValidateWithErrors<T> (this IValidator<T> validator, T value)
    {
        var validationResult = validator.Validate(value);
        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errors);
        }

        return value;
    }
}