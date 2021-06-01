using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interface
{
    public interface IUserRepository
    {
        public bool AddNewUser(RegisterModel userData);
        public bool Login(string email, string password);
        public bool ResetPassword(ResetPasswordModel resetModel);
        public string GenerateToken(string email);
        public bool SendEmail(string emailAddress);
    }
}
