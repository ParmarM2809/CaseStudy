using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Entity;
using UserService.ViewModel;
using Utility;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("Registration")]
        public ResultObject RegisterUser(UserModel userModel)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultObject = new ResultObject(APIResponseMessage.DataNotValid, StatusType.NotFound);
                    return resultObject;
                }
                new UserEntity().AddUser(userModel);
                resultObject = new ResultObject(APIResponseMessage.DataSaved, StatusType.Success);

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
