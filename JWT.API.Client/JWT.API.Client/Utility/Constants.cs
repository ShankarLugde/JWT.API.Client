using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace JWT.API.Client
{
    public class Constants
    {
        public const string MediaType_App_Json = "application/json";
        public const string Scheme_Bearer = "Bearer";
        public static string GetJWTToken_BaseUrl()
        {
            return WebConfigurationManager.AppSettings["JWTTokenBaseUrl"];
        }
    }

    public static class Sessions
    {
        public const string TokenWithUser = "TokenWithUser";
        public const string Error = "Error";
        public const string UserFullName = "UserFullName";
        public const string UserName = "UserName";
        public const string RoleName = "RoleName";
    }

    public static class Role
    {
        public const string RoleRWD = "RoleRWD";
        public const string RoleR = "RoleR";
        public const string RoleW = "RoleW";
        public const string RoleD = "RoleD";
    }
}