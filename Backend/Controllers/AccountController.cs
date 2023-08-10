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
        private readonly IDbRepo _dbRepo;
        private readonly DataContext _dataContext;

        public AccountController(IDbRepo dbRepo, DataContext dataContext)
        {
            _dbRepo = dbRepo;
            _dataContext = dataContext;
        }



    }
}
