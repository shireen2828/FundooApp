using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
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
        public bool SendEmail(string emailAddress)
        {
            try
            {

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("anishadas880@gmail.com");
                message.To.Add(new MailAddress(emailAddress));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "body";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("anishadas880@gmail.com", "Anisha@880");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
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

