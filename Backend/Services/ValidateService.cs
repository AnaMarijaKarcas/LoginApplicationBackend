using System;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services
{
    public class ValidateService : IValidateService
    {
        public ValidateService()
        {
        }

        public bool isValid(string userName, string password)
        {
            //provera duzine, sadrzaja,...
            if (userName == null || password == null)
                return false;
            else
                return true;
        }

        public bool isValidRegistration(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName))
                return false;
            else
                return true;
        }
    }
}
