using System;
using System.Linq;
using Backend.DTOs;
using FluentValidation;

namespace Backend.Validations
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(login => login.UserName).NotEmpty().WithMessage("Email address not valid.");
            RuleFor(login => login.Password).NotEmpty().MinimumLength(8).WithMessage("Must be at least 8 characters long.");
        }
        public void ValidateAndThrow(Login login)
        {
            var validationResult = Validate(login);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                throw new ValidationException("Validation failed " + string.Join(", ", errors));
            }
        }
    }
}
