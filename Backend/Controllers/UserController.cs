using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                if (users.Count == 0)
                {
                    return NotFound("No users found!");
                }
                return Ok(users);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching users from the database.");                
            }

        } 
    }
}
