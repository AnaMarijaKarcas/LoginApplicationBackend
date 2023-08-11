using System;
using Backend.DTOs;

namespace Backend.Interfaces
{
    public interface IValidateService
    {
        public bool IsValid(Login login);
    }
}
