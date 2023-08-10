using Microsoft.AspNetCore.Mvc;
using Backend.Repo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Data;

namespace Backend.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _dataContext;

        public AccountController(IUserRepository userRepository, DataContext dataContext)
        {
            _userRepository = userRepository;
            _dataContext = dataContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
           
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
