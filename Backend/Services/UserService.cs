using System;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO;
using Backend.DTOs;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repo;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepo _dbRepo;
        public UserService(IDbRepo dbRepo)
        {
            _dbRepo = dbRepo;
        }

        public bool CheckForUser(Login login)
        {
            
            var user = _dbRepo.FindUserByEmail(login.UserName);
            if (user != null && CheckPassword(login.Password, user.Password))
            {
                return true;
            }
            else return false;
        }

        public bool CheckPassword(string password, string userPassword)
        {
            if (password == userPassword)
                return true;
            else
                return false;
        }
       
         public async Task<bool> RegisterUser(Registration user)
		{
            try
			{
               _dbRepo.Save(user);
                await _dbRepo.SaveAsync();
                return true;
            }
            catch(Exception)
			{
                return false;
			}
		}
    }
}
