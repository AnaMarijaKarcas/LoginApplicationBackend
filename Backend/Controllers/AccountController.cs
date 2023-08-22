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

namespace Backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors]
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
                    return Ok(StatusCodesEnums.UserLoginSuccessful);
                return BadRequest(StatusCodesEnums.InvalidCredentials);
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
                    return Ok("OK");
                return StatusCode(400, StatusCodesEnums.UserAlreadyRegistered);
            }
            catch (Exception)
            {
                return StatusCode(500, StatusCodesEnums.ServerError);
            }

        }

    }
}
