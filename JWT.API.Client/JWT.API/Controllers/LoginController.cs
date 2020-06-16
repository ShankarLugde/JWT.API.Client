using JWT.API.ADOHelper;
using JWT.API.CustomFilters;
using JWT.API.JWT;
using JWT.API.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWT.API.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/Login/Get")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Ready ");
        }

        [HttpPost]
        [Route("api/Login/GenerateTokenByUser")]
        public HttpResponseMessage GenerateTokenByUser(Login login)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            string error = string.Empty;
            var result = TokenManager.GenerateToken(login, ref error);

            if (string.IsNullOrEmpty(error))
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, result);
            else
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized, "User Not Found");
            return httpResponseMessage;
        }

    }
}
