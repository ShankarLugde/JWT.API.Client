using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JWT.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Values",
                routeTemplate: "api/Values/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
