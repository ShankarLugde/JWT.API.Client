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
        [Route("api/Login/Login")]
        public HttpResponseMessage Login(Login login)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            if (new LoginHelper().Validate_User(login).Rows.Count > 0)
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(login));
            else
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized, "User Not Found");
            return httpResponseMessage;
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/Login/GetAllEmp")]
        public HttpResponseMessage GetAllEmp()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Get_Emp(new Employee()));
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/Login/GetEmpBy")]
        public HttpResponseMessage GetEmpBy(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Get_Emp(employee));
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/Login/InsEmp")]
        public HttpResponseMessage InsEmp(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Ins_Emp(employee));
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/Login/UpdEmp")]
        public HttpResponseMessage UpdEmp(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Upd_Emp(employee));
        }

        [HttpPost]
        [CustomAuthenticationFilter]
        [Route("api/Login/DelEmp")]
        public HttpResponseMessage DelEmp(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Del_Emp(new Employee()));
        }

    }
}
