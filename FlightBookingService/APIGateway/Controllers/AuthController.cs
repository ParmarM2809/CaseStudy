using APIGateway.Models;
using APIGateway.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Utility;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        [Route("LogIn")]
        public IActionResult LogIn(AuthUser authUser)
        {
            ResultObject resultObject = new ResultObject();
            try
            {
                UserMaster userMaster = new AuthorizationService().IsUserValid(authUser);
                if (userMaster != null)
                {
                    AuthToken auth = new CategoriesApiTokenService().GenerateToken(authUser);
                    userMaster.Token = auth.Token;
                }
                else
                {
                    return BadRequest(new { message = "Username or Password is invalid" });
                }
                return Ok(userMaster);
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

        [HttpPost]
        [Route("categories")]
        [AllowAnonymous]
        public ActionResult<AuthToken> GetCategoriesAuthentication([FromBody] AuthUser user)
        {
            if (user.Email != "categories_user" || user.Password != "456")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new CategoriesApiTokenService().GenerateToken(user);
        }

        [HttpPost]
        [Route("products")]
        [AllowAnonymous]
        public ActionResult<AuthToken> GetProductsAuthentication([FromBody] AuthUser user)
        {
            if (user.Email != "products_user" || user.Password != "123")
            {
                return BadRequest(new { message = "Username or Password is invalid" });
            }

            return new ProductsApiTokenService().GenerateToken(user);
        }
    }
}
