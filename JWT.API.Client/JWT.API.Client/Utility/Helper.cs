using JWT.API.Client;
using System.Web;

namespace Utility
{
    public class Helper
    {
        public static string GetUserId()
        {
            return HttpContext.Current.Session[Sessions.UserName] != null ? HttpContext.Current.Session[Sessions.UserName].ToString() : "";
        }

        public static string GetTokenWithUser()
        {
            return HttpContext.Current.Session[Sessions.TokenWithUser] != null ? HttpContext.Current.Session[Sessions.TokenWithUser].ToString() : "";
        }

        public static string GetRole()
        {
            return HttpContext.Current.Session[Sessions.RoleName] != null ? HttpContext.Current.Session[Sessions.RoleName].ToString() : "";
        }
        public static string GetUserFullName()
        {
            return HttpContext.Current.Session[Sessions.UserFullName] != null ? HttpContext.Current.Session[Sessions.UserFullName].ToString() : "";
        }
        public static bool RoleRWD()
        {
            if (GetRole() == Role.RoleRWD)
                return true;
            return false;
        }
        public static bool RoleR()
        {
            if (GetRole() == Role.RoleR)
                return true;
            return false;
        }
        public static bool RoleW()
        {
            if (GetRole() == Role.RoleW)
                return true;
            return false;
        }
        public static bool RoleD()
        {
            if (GetRole() == Role.RoleD)
                return true;
            return false;
        }
    }
}