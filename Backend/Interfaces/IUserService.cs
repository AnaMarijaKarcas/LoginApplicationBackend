using System;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        public bool CheckForUser(string userName, string password);
        public Task<bool> RegisterUser(User user);
    }
}
