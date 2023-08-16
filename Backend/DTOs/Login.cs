using System;
using Backend.Validations;

namespace Backend.DTOs
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Login(string userName, string password)
        {
            UserName = userName;
            Password = password;

            var validator = new LoginValidator();
            validator.ValidateAndThrow(this);
        }
    }
}
