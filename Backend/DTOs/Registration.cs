using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Backend.Validations;

namespace Backend.DTO
{
    public class Registration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
<<<<<<< HEAD:Backend/DTO/Registration.cs
        public string Email { get; set; }
=======
>>>>>>> b93b8f9f8a841f4b7830d2b3e75ed83fea2b376f:Backend/DTOs/Registration.cs
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Registration()
        {

        }
        public Registration(string firstName, string lastName, string email, string password, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = email;
            Password = password;

            var validator = new RegistrationValidator();
            validator.ValidateAndThrow(this);
        }
    }
}
