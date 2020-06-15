using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWT.API.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/Values/Get")]
        public string Get()
        {
            return "Buddy we are Ready !!!!";
        }
    }
}
