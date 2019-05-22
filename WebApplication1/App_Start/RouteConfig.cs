using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "display",
                url: "{controller}/{ip}/{port}",
                defaults: new { controller = "Display", action = "Display", ip = UrlParameter.Optional, port = UrlParameter.Optional }
            );
        }
    }
}
