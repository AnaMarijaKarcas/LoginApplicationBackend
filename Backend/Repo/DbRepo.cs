using Backend.Data;
using Backend.DTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repo
{
    public class DbRepo : IDbRepo
    {
        private readonly DataContext _context;
        public DbRepo(DataContext context)
        {
            _context = context;
        }
        public User FindUserByUserName(string userName)
        {
            return  _context.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public void Save(Registration register)
        {

            User user = new User(register.FirstName, register.LastName,register.UserName, register.Email, register.Password, "user");


            _context.Users.Add(user);

        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public bool DoesUserExist(string email, string username)
        {
            return _context.Users.Any(u => u.Email == email || u.UserName == username);
        }
    }
}
