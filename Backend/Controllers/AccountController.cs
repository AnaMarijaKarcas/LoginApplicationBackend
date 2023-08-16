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

namespace Backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> Login([FromBody] Login login)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                if (_userService.CheckUser(login))
                    return StatusCode(200, new { message = "User successfully logged in." });
                return StatusCode(400, new { message = "User with that credentials is not found" });
            }
            catch (Exception)
            {
                throw new Exception("An error occured");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Registration register)
		{
            
            try
            {
                bool retVal = await _userService.RegisterUser(register);
                if (retVal)
                    return Ok(new{message = "User registration successful!"});
                return StatusCode(500, new { message = "User registration failed." });
            }
            catch (Exception)
            {
                throw new Exception("An error occured");
            }
            
        }

    }
}
