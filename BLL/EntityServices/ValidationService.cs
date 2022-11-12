using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.BLL.EntityServices
{
    internal class ValidationService
    {
        public bool ValidateEmail(string? email)
        {
            if (string.IsNullOrEmpty(email)) 
                return false;
            return true;
        }

        public bool ValidateUserName(string? userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName)) 
                return false;
            return true;
        }

        public bool ValidatePasswords(string? password, string? passwordConfirm)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm)) 
                return false;            
            return password == passwordConfirm;
        }
    }
}
