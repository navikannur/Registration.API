using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace Registration.API.Application.Domain.Common;

public class RegistrationDate : ValueOf<DateOnly, RegistrationDate>
{
    protected override void Validate()
    {
        if (Value > DateOnly.FromDateTime(DateTime.Now))
        {
            const string message = "Your date of birth cannot be in the future";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(RegistrationDate), message)
            });
        }
    }
}
