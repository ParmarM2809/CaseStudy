using AdminService.Entity;
using AdminService.ViewModel;
using DAL.Models;
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
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        public ResultObject LogIn(User user)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                UserMaster userMaster = new AuthorizationEntity().IsAdminValid(user);
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
    }
}
