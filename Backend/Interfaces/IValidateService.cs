using System;
namespace Backend.Interfaces
{
    public interface IValidateService
    {
        public Boolean isValid(string userName, string password);
    }
}
