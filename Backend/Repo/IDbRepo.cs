using Backend.DTO;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repo
{
    public interface IDbRepo
    {
        public void Save(Registration register);
        public User FindUserByUserName( string userName);
        public Task<List<User>> GetAllUsers();

        Task SaveAsync();
    }
}
