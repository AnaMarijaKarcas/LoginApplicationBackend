using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.DTOs;
using Backend.Interfaces;
using Backend.Repo;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbRepo _dbRepo;
        public TokenService(IConfiguration configuration, IDbRepo dbRepo)
        {
            _configuration = configuration;
            _dbRepo = dbRepo;
        }

        public string CreateToken(Login login)
        {
            var user = _dbRepo.FindUserByUserName(login.UserName);
            if (user == null)
            {
                return "User not found";
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSigningKey"]));
            var cred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
