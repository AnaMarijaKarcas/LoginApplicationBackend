using System;
using Backend.DTOs;
using Backend.Interfaces;

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
    }
}
