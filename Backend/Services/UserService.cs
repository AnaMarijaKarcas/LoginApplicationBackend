using System;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO;
using Backend.DTOs;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repo;
using BCrypt;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepo _dbRepo;
        public UserService(IDbRepo dbRepo)
        {
            _dbRepo = dbRepo;
        }

        public bool CheckUser(Login login)
        {
            
            var user = _dbRepo.FindUserByEmail(login.UserName);
            if (user != null && CheckPassword(login.Password, user.Password))
            {
                return true;
            }
            else return false;
        }

        private bool CheckPassword(string password, string userPassword)
        {
            if(BCrypt.Net.BCrypt.Verify(password, userPassword))
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
