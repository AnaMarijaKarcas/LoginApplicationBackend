using System;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repo;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepo _dbRepo;
        private readonly DataContext _dataContext;
        public UserService(IDbRepo dbRepo, DataContext dataContext)
        {
            _dbRepo = dbRepo;
            _dataContext = dataContext;
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
