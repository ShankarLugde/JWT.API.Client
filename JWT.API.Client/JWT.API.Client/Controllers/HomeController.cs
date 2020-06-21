using JWT.API.Client.JWTAPICall;
using JWT.API.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWT.API.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session[Sessions.Error] != null)
                TempData[Sessions.Error] = Session[Sessions.Error].ToString();

            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            var Userdata = TokenManager.GenerateTokenByUser(login);
            if (string.IsNullOrEmpty(Userdata.LoginError.ErrorMessage))
            {
                Session[Sessions.TokenWithUser] = Userdata.Token + ":" + Userdata.UserName;
                Session[Sessions.UserName] = Userdata.UserName;
                Session[Sessions.UserFullName] = Userdata.FirstName + " " + Userdata.LastName;
                Session[Sessions.RoleName] = Userdata.RoleName;
                return Redirect("~/Dashboard/Index");
            }
            else
            {
                TempData[Sessions.Error] = Userdata.LoginError.ErrorMessage;
                return View(nameof(Index), login);
            }
        }
    }
}