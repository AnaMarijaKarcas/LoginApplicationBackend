﻿using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repo
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetUserByUsername(string username);
    }
}
