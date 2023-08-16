using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTO;
using FluentValidation;

namespace Backend.Validations
{
    public class RegistrationValidator : AbstractValidator<Registration>
    {
        public RegistrationValidator()
        {
            RuleFor(registration => registration.FirstName).NotEmpty().WithMessage("First name cannot be empty.");
            RuleFor(registration => registration.LastName).NotEmpty().WithMessage("Last name cannot be empty.");
            RuleFor(registration => registration.UserName).NotEmpty().WithMessage("Username cannot be empty.");
            RuleFor(registration => registration.Email).NotEmpty().EmailAddress().WithMessage("Email address not valid.");
            RuleFor(registration => registration.Password).NotEmpty().MinimumLength(8).WithMessage("Must be at least 8 characters long.");
        }

        public void ValidateAndThrow(Registration registration)
        {
            var validationResult = Validate(registration);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                throw new ValidationException("Validation failed " + string.Join(", ", errors));
            }
        }
    }
}
