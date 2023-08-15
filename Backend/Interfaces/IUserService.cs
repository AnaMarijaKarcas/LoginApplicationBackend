using System;
using System.Threading.Tasks;

using Backend.DTOs;

using Backend.DTO;

using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        public bool CheckUser(Login login);
        public Task<bool> RegisterUser(Registration register);

    }
}
