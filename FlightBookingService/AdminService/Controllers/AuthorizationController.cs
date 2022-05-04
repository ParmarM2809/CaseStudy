using AdminService.Entity;
using AdminService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        public IActionResult LogIn(User user)
        {
            bool IsValid = true;
            new AuthorizationEntity().IsAdminValid(user);
            return IsValid ? Ok() : Ok();
        }
    }
}
