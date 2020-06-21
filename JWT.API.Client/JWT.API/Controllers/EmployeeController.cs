using JWT.API.ADOHelper;
using JWT.API.Client.CustomFilters;
using JWT.API.CustomFilters;
using JWT.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWT.API.Controllers
{
    [CustomAuthenticationFilter]
    public class EmployeeController : ApiController
    {
        [Route("api/Employee/Get")]
        public string Get()
        {
            return "Employee Controller are Ready !!!!";
        }

        [HttpPost]
        [Route("api/Employee/GetAllEmp")]
        public HttpResponseMessage GetAllEmp()
        {
            var data = new EmployeeHelper().Get_Emp(new Employee());
            if (data != null && data.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
                };
                return response;
            }
        }

        [HttpPost]
        [Route("api/Employee/GetEmpBy")]
        public HttpResponseMessage GetEmpBy(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Get_EmpBy(employee));
        }

        [HttpPost]
        [Route("api/Employee/InsEmp")]
        public HttpResponseMessage InsEmp(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Ins_Emp(employee));
        }

        [HttpPut]
        [Route("api/Employee/UpdEmp")]
        public HttpResponseMessage UpdEmp(Employee employee)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Upd_Emp(employee));
        }

        [HttpDelete]
        [Route("api/Employee/DelEmp")]
        public HttpResponseMessage DelEmp(int EmpId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new EmployeeHelper().Del_Emp(EmpId));
        }

    }
}
