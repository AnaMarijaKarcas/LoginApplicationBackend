using System;
namespace Backend.Interfaces
{
    public interface IValidateService
    {
        public bool isValid(string userName, string password);
    }
}
