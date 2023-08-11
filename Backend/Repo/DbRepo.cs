using Backend.Data;
using Backend.DTO;
using Backend.Models;
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
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void Save(Registration register)
        {
            User user = new User { Email = register.Email, FirstName = register.FirstName, LastName = register.LastName, Password = register.Password };
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
    }
}
