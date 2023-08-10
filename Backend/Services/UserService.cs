using System;
using System.Threading.Tasks;
using Backend.Data;
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

        //public bool CheckForUser(string userName, string password)
        //{
        //    if (_dbRepo.FindUserByEmail(userName) != null)
        //    {

        //    }
        //}

       
        public async Task<bool> RegisterUser(User user)
		{
            try
			{
               _dbRepo.Save(user);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
			{
                return false;
			}
		}

    }
}
