using Microsoft.AspNetCore.Mvc;
using Backend.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Data;
using Backend.Interfaces;
using Backend.DTOs;
using Backend.DTO;
using Microsoft.AspNetCore.Cors;
using BCrypt;
using Backend.Enums;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService,ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet("login")]
        public IActionResult Login([FromBody] Login login)
        {
            try
            {
                if (!_userService.CheckUser(login))
                        return Unauthorized();
                return Ok(_tokenService.CreateToken(login));
                
            }
            catch (Exception)
            {
                return StatusCode(500, StatusCodesEnums.ServerError);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Registration register)
		{
            try
            {
                bool retVal = await _userService.RegisterUser(register);
                if (retVal)
                    return Ok(StatusCodesEnums.UserRegistrationSuccessful);
                return StatusCode(400, StatusCodesEnums.UserAlreadyRegistered);
            }
            catch (Exception)
            {
                return StatusCode(500, StatusCodesEnums.ServerError);
            }

        }

        
    }
}
