// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooApp.Controllers
{
    using System;
    using FundooManager.Interfaces;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using StackExchange.Redis;

    /// <summary>
    /// class for user controller
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// private method for IUser manager
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// method for user controller
        /// </summary>
        /// <param name="manager"></manager>
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// request for register model
        /// </summary>
        /// <param name="userData"></userData>
        /// <returns></returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                var result = this.manager.AddNewUser(userData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<RegisterModel>() { Status = true, Message = "New User Added Successfully !" });
                }

                return this.BadRequest(new ResponseModel<RegisterModel>() { Status = false, Message = "Unable to Add New User" });            
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<RegisterModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for login employee model
        /// </summary>
        /// <param name="model"></model>
        /// <returns></returns>
        [HttpPost]
        [Route("api/loginEmployee")]
        public ActionResult LoginEmployee([FromBody]LoginModel model)
        {
            try
            {
                var result = this.manager.Login(model.Email, model.Password);
                if (result.Equals(true))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    database.StringSet(key: "FundooToken", this.manager.GenerateToken(model.Email));
                    string tokenString = database.StringGet("FundooToken");
                    ///string tokenstring = this.manager.GenerateToken(model.Email);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Login Sucessfully", Data = tokenString });
                }

                return this.BadRequest(new { Status = false, Message = "Failed to login the user :Email or Password mismatched" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// request for forgot password
        /// </summary>
        /// <param name="emailAddress"></emailAddress>
        /// <returns></returns>
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

        /// <summary>
        /// request for reset password
        /// </summary>
        /// <param name="resetModel"></resetModel>
        /// <returns></returns>
        [HttpPost]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetModel)
        {
            try
            {
                bool result = this.manager.ResetPassword(resetModel);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<ResetPasswordModel>() { Status = true, Message = "Password Changed" });
                }

                return this.BadRequest(new ResponseModel<ResetPasswordModel>() { Status = false, Message = "cannot change password" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<ResetPasswordModel>() { Status = false, Message = ex.Message });
            }
        }
    }
}