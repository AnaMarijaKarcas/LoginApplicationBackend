using System;
using System.Threading.Tasks;

using Backend.DTOs;

using Backend.DTO;

using Backend.Models;
using System.Collections.Generic;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        public bool CheckUser(Login login);
        public Task<bool> RegisterUser(Registration register);

        public Task<List<User>> GetAllUsers();

    }
}
