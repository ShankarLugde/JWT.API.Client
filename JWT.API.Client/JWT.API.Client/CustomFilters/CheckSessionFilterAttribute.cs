using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWT.API.Client.CustomFilters
{
    /// <summary>
    /// CheckSessionFilterAttribute
    /// </summary>
    public class CheckSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session[Sessions.TokenWithUser] == null)
            {
                filterContext.HttpContext.Session[Sessions.Error] = "Your session has been expired, please login again.";
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }

}
