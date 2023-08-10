using System;
using Backend.Interfaces;
using Backend.Repo;

namespace Backend.Services
{
    public class UserService: IUserService 
    {
        private readonly IDbRepo _dbRepo;
        public UserService(IDbRepo dbRepo)
        {
            _dbRepo = dbRepo;
        }

        public bool CheckForUser(string userName, string password)
        {
            var user = _dbRepo.FindUserByEmail(userName);
            if (user != null && CheckPassword(password, user.Password))
            {
                return true;
            }
            else return false;
        }


        private bool CheckPassword(string password, string userPassword)
        {
            if (password == userPassword)
                return true;
            else
                return false;
        }

    }
}
