using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO;
using Backend.DTOs;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repo;
using BCrypt;
using Microsoft.AspNetCore.Mvc;

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
            
            var user = _dbRepo.FindUserByUserName(login.UserName);
            if (user != null && CheckPassword(login.Password, user.Password))
            {
                return true;
            }
            else return false;
        }

        private bool CheckPassword(string password, string userPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, userPassword);
        }
       
         public async Task<bool> RegisterUser(Registration user)
		{
            try
			{
                string passHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = passHash;
                _dbRepo.Save(user);
                await _dbRepo.SaveAsync();
                return true;
            }
            catch(Exception)
			{
                return false;
			}
		}
        
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await _dbRepo.GetAllUsers();
            return users;
        }
    }
}
