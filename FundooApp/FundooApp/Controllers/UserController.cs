using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundooManager.Interfaces;
using FundooModels;

namespace FundooApp.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FullBody] RegisterModel userData)
        {
            try
            {
                var result = this.manager.AddNewUser(userData);
                if(result== true)
                {
                    return this.Ok(new ResponseModel<RegisterModel>() { Status = true, Message = "New User Added Successfully !" });
                }
                return this.BadRequest(new ResponseModel<RegisterModel>() { Status = false, Message = "Unable to Add New User" });
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<RegisterModel>() { Status = false, Message = ex.Message });
            }
          
        }
        [HttpPost]
        [Route("api/loginEmployee")]
        public ActionResult LoginEmployee(LoginModel model)
        {
            try
            {

                var result = this.manager.Login(model.Email, model.Password);
                if (result.Equals(true))
                {

                    return this.Ok(new { Status = true, Message = "Login Sucessfully", });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to login the user :Email or Password mismatched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/forgetPassword")]
        public IActionResult ForgotPassword(string emailAddress)
        {
            try
            {
                var result = this.manager.SendEmail(emailAddress);
                if (result.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Mail Sent Sucessfully", Data = emailAddress });
                }
                return this.BadRequest(new { Status = false, Message = "Email is not correct:Please enter valid email" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
   
