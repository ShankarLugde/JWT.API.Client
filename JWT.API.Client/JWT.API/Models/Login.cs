using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.API.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
        public LoginResponseError LoginError { get; set; }
        
    }
    public class LoginResponseError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

}