using System;
using Backend.DTOs;
﻿using Backend.Models;


namespace Backend.Interfaces
{
    public interface IValidateService
    {
        public bool IsValid(Login login);
        public bool isValidRegistration(User user);
    }
}
