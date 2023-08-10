using System;
using Backend.Interfaces;

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
    }
}
