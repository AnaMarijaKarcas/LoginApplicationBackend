using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;

namespace Backend.Interfaces
{
    public interface ICryptography
    {
        public string EncryptPassword(string password);
        public bool VerifyPassword(string password, string passwordToCompare);
    }
}
