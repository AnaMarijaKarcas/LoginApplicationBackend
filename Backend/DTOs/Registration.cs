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
<<<<<<< HEAD:Backend/DTOs/Registration.cs
=======
        public string Email { get; set; }
>>>>>>> develop:Backend/DTO/Registration.cs
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Registration()
<<<<<<< HEAD:Backend/DTOs/Registration.cs
        {

        }
        public Registration(string firstName, string lastName, string userName, string email, string password)
=======
		{

		}
        public Registration(string firstName, string lastName, string email, string password, string username)
>>>>>>> develop:Backend/DTO/Registration.cs
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
