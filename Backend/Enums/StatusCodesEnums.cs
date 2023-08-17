﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Enums
{
    public enum StatusCodesEnums
    {
        UserAlreadyRegistered,
        UserRegistrationSuccessful,
        UserRegistrationFailed,
        ServerError,
        UserLoginSuccessful,
        InvalidCredentials
    }
}
