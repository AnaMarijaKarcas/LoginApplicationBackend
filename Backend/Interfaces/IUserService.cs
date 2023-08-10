using System;
namespace Backend.Interfaces
{
    public interface IUserService
    {
        public bool CheckForUser(string userName, string password);
    }
}
