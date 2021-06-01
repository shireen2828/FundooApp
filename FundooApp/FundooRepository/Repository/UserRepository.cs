// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Shireen kk"/>
//---------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interface;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// method for user repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// method for user context and configuration
        /// </summary>
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;

        /// <summary>
        /// constructor method for user repository
        /// </summary>
        /// <param name="userContext"></user context>
        /// <param name="configuration"></configuration>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// method for add new user
        /// </summary>
        /// <param name="userData"></user Data>
        /// <returns></returns>
        public bool AddNewUser(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    userData.Password = EncryptPassword(userData.Password);
                    this.userContext.RegisterModels.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method to encrypt password
        /// </summary>
        /// <param name="password"></password>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encryptData = new byte[password.Length];
                encryptData = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encryptData);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// method to login
        /// </summary>
        /// <param name="email"></email>
        /// <param name="password"></password>
        /// <returns></returns>
        public bool Login(string email, string password)
        {
            try
            {
                password = EncryptPassword(password);
                var login = this.userContext.RegisterModels.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
                if (login != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method to generate token
        /// </summary>
        /// <param name="Email"></Email>
        /// <returns></returns>
        public string GenerateToken(string Email)
        {
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("Email", Email)
                        }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:SecureKey"])), SecurityAlgorithms.HmacSha256)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// method to send email
        /// </summary>
        /// <param name="emailAddress"></emailAddress>
        /// <returns></returns>
        public bool SendEmail(string emailAddress)
        {
            try
            {
                MailMessage message = new MailMessage();
                //SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("shireenkk28@gmail.com");
                message.To.Add(new MailAddress(emailAddress));
                message.Subject = "forget password link";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "body";
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("shireenkk28@gmail.com", "shireenkk@28")
                };
                //smtp.Port = 587;
                //smtp.Host = "smtp.gmail.com"; //for gmail host  
                //smtp.EnableSsl = true;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("nurainkk0110@gmail.com", "nurainkk@0110");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// method to reset password
        /// </summary>
        /// <param name="resetModel"></reset model>
        /// <returns></returns>
        public bool ResetPassword(ResetPasswordModel resetModel)
        {
            try
            {
                var user = this.userContext.RegisterModels.Where(x => x.Email == resetModel.Email).SingleOrDefault();
                if (resetModel != null && user != null)
                {
                    user.Password = resetModel.NewPassword;
                    this.userContext.RegisterModels.Update(user);
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void SendMessage()
        //{
        //    var body = "Click on following link to reset your credentials for Fundoo Notes App: ";
        //    MessageQueue msmqQueue = new MessageQueue();
        //    if (MessageQueue.Exists(@".\Private$\MyQueue"))
        //    {
        //        msmqQueue = new MessageQueue(@".\Private$\MyQueue");
        //    }
        //    else
        //    {
        //        msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");
        //    }
        //    Message message = new Message message = new Message();
        //    message.Formatter = new BinaryMessageFormatter();
        //    message.Body = body;
        //    msmqQueue.Label = "url link";
        //    msmqQueue.Send(message);
        //}
        //public string receiverMessage()
        //{
        //    MessageQueue reciever = new MessageQueue(@".\Private$\MyQueue");
        //    var recieving = reciever.Receive();
        //    recieving.Formatter = new BinaryMessageFormatter();
        //    string body = recieving.Body.ToString();
        //    return body;
        //}
    }
}