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

        public const string Success = "Success";
        public const string Error = "Error";
        public const string UserId = "UserId";
        public const string UserTypeId = "UserTypeId";
        public const string OrganizationId = "OrganizationId";
        public const string UserFullName = "UserFullName";

    }
}