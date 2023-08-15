using System;
using Backend.DTOs;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services
{
    public class ValidateService : IValidateService
    {
        public ValidateService()
        {
        }

        public bool IsValid(Login login)
        {
            if (string.IsNullOrEmpty(login.UserName) || string.IsNullOrEmpty(login.UserName))
                return false;
            else
                return true;
        }

        public bool isValidRegistration(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.FirstName)
                || string.IsNullOrEmpty(user.LastName))
                return false;
            else
                return true;
        }
    }
}
