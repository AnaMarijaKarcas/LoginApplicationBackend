using Backend.Models;
using System;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        // public bool CheckForUser(string userName, string password);

        Task<bool> RegisterUser(User user);

    }
}
