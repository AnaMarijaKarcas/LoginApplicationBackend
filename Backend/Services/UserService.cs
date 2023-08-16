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
        private readonly ICryptography _cryptography;
        public UserService(ICryptography cryptography, IDbRepo dbRepo)
        {
            _dbRepo = dbRepo;
            _cryptography = cryptography;
        }

        public bool CheckUser(Login login)
        {
            
            var user = _dbRepo.FindUserByEmail(login.UserName);
            if (user != null && _cryptography.VerifyPassword(login.Password, user.Password))
                return true;
            return false;
        }

         public async Task<bool> RegisterUser(Registration user)
		{
            if (!_dbRepo.DoesUserExist(user.Email, user.UserName))
            {
                user.Password = _cryptography.EncryptPassword(user.Password);
                _dbRepo.Save(user);
                await _dbRepo.SaveAsync();
                return true;
            }
            return false;
		}
        
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await _dbRepo.GetAllUsers();
            return users;
        }
    }
}