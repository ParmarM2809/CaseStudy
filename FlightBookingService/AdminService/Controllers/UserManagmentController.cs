using AdminService.Entity;
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
    [Route("api/UserManagment")]
    [ApiController]
    public class UserManagmentController : ControllerBase
    {

        [HttpGet]
        [Route("UserList")]
        public IActionResult UserList()
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                List<UserMaster> userMasters = new UserManagmentEntity().UserList();
                resultObject = new ResultObject(APIResponseMessage.DataFound, StatusType.Success);
                resultObject.ResultData = userMasters;
                return Ok(userMasters);
            }
            catch (Exception ex)
            {
                resultObject = new ResultObject(APIResponseMessage.SomethingWrong, StatusType.Error);
                resultObject.ExceptionMessage = ex.Message;
                resultObject.ExceptionStackTrace = ex.StackTrace;
                resultObject.ResultException = ex.InnerException;
                return NotFound();
            }
        }


    }
}
