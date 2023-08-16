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
        public User FindUserByEmail(string email)
        {
            return  _context.Users.FirstOrDefault(u => u.UserName == email);
        }

        public void Save(Registration register)
        {
            User user = new User(register.FirstName, register.LastName,register.Email, register.Username, register.Password);

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
    }
}
