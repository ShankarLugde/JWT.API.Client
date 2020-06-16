using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JWT.API.Client.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public LoginResponseError LoginError { get; set; }
    }
    public class LoginResponseError
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}