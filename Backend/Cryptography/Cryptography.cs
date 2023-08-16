using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Cryptography
{
    public class Cryptography : ICryptography
    {

        public string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordToCompare)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordToCompare);
        }
    }
}
