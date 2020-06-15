using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT.API.Models
{
    public class Employee
    {
        public int EmpId;
        public string FirstName;
        public string LastName;
        public string Mobile;
        public string EmailId;
        public string Gender;
        public DateTime DateOfBirth;
        public bool IsActive;

    }
}