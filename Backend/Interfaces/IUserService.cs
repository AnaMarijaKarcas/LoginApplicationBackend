using System;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CheckForUser(Login login);
        public Task<bool> RegisterUser(User user);
    }
}
