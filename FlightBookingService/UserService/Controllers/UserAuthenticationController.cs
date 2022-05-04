using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Entity;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("Registration")]
        public IActionResult RegisterUser(UserMaster userMaster)
        {
            new UserEntity().AddUser(userMaster);
            return Ok();
        }

    }
}
