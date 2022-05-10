using AdminService.Entity;
using AdminService.Interface;
using AdminService.ViewModel;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace AdminService.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly IJWTManagerRepository iJWTManager;

        private readonly IAuthorization iauthorization;

        public AuthorizationController(IJWTManagerRepository jWTManager)
        {
            iJWTManager = jWTManager;
        }

        public AuthorizationController(IAuthorization authorization)
        {
            iauthorization = authorization;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LogIn")]
        public ResultObject LogIn(User user)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                var token = iJWTManager.Authenticate(user);
                if (token == null)
                {
                    return resultObject;
                }
                UserMaster userMaster = iauthorization.IsAdminValid(user);
                userMaster.Token = Convert.ToString(token.Token);
                resultObject = userMaster == null ?
                        new ResultObject(APIResponseMessage.LogInDetailNotValid, StatusType.NotFound)
                        : new ResultObject(APIResponseMessage.LogInSucess, StatusType.Success);
                resultObject.ResultData = userMaster;
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
            }
            return resultObject;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("authenticate")]
        //public IActionResult Authenticate(User userdata)
        //{
        //    var token = iJWTManager.Authenticate(userdata);
        //    if (token == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(token);
        //}

        //[HttpGet]
        //public List<string> Get()
        //{
        //    var users = new List<string> { "Mital", "Mital Parmar" };
        //    return users;
        //}
    }
}
