﻿using System;
using Backend.Interfaces;
using Backend.Repo;

namespace Backend.Services
{
    public class UserService: IUserService 
    {
        private readonly IDbRepo _dbRepo;
        public UserService(IDbRepo dbRepo)
        {
            _dbRepo = dbRepo;
        }

        public bool CheckForUser(string userName, string password)
        {
            if (_dbRepo.FindUserByEmail(userName) != null)
            {

            }
        }
    }
}
