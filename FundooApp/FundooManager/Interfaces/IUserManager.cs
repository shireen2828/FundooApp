using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface IUserManager
    {
        public bool AddNewUser(RegisterModel userData);
        public bool Login(string email, string password);
        public bool ResetPassword(ResetPasswordModel resetModel);
        public bool SendEmail(string emailAddress);
        public string GenerateToken(string email);
    }
}
