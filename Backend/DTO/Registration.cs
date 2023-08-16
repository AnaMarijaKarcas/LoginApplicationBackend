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
<<<<<<< HEAD
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public Registration(string firstName, string lastName, string email, string password, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
=======
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public Registration(string firstName, string lastName, string userName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
>>>>>>> develop
            Email = email;
            Password = password;

            var validator = new RegistrationValidator();
            validator.ValidateAndThrow(this);
        }
    }
}
