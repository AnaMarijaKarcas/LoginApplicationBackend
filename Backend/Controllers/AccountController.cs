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
        public IActionResult Login(string userName, string password)
        {
            if (!_validateService.isValid(userName, password))
            {
                return BadRequest("User not found");
            }

            if (_userService.CheckForUser(userName, password))
            {
                return Ok("User successfully logged in.");
            }
            else
                return NotFound("User with that credentials is not found");

        }
        public AccountController(IUserService userService)
        {
            _userService = userService;
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
