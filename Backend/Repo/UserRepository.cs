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

        };

        public List<User> GetAllUsers()
        {
            return users;
        }

    }
}
