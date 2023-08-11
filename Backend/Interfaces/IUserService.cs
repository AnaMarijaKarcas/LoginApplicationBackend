using System;
using System.Threading.Tasks;

using Backend.DTOs;

using Backend.DTO;

using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        public bool CheckForUser(Login login);
        public Task<bool> RegisterUser(Registration register);

    }
}
