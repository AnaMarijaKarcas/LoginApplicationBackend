using Microsoft.AspNetCore.Mvc;
using Backend.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = _userRepository.GetUserByUsername(request.Username);

            if (user == null || user.Password != request.Password)
            {
                return Unauthorized();
            }

            return Ok(new { Message = "Uspesno logovanje!" });
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            List<User> users = _userRepository.GetAllUsers();
            return Ok(users);
        }
    }
}
