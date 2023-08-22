using System;
using Backend.DTOs;

namespace Backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Login login);
    }
}
