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

namespace Backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidateService _validateService;

        public AccountController(IUserService userService, IValidateService validateService)
        {
            _userService = userService;
            _validateService = validateService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!_validateService.IsValid(login))
            {
                return StatusCode(400, new { message = "There was an error in credentials" });
            }

            if (_userService.CheckForUser(login.UserName, login.Password))
            {
                return StatusCode(200, new { message = "User successfully logged in." });
            }
            else
                return StatusCode(400, new { message = "User with that credentials is not found" });

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
		{
            bool retVal =  await _userService.RegisterUser(user);

            if (retVal)
            {
                return Ok(new 
                { 
                    message = "User registration successful!" });
            }
            else
            {
                return StatusCode(500, new { message = "User registration failed." });
            }
        }

    }
}
