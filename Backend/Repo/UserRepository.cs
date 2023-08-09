using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repo
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        { 
            new User { Id = 1, FirstName = "ime", LastName = "prezime", Username = "ime@mail.com", Password = "12345"},
            new User { Id = 2, FirstName = "admin", LastName = "adminic", Username = "admin@mail.com", Password = "123"}
        };

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }


    }
}
