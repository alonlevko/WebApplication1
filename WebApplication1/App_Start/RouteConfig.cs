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
                url: "{controller}/{ip}/{port:int}",
                defaults: new { controller = "Display", action = "Display", ip = UrlParameter.Optional, port = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "display",
                url: "{controller}/{ip}/{port:int}/{seconds:int}",
                defaults: new { controller = "Display", action = "DisplayRouth", ip = UrlParameter.Optional, port = UrlParameter.Optional,
                    seconds = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "save",
                url: "{controller}/{ip}/{port:int}/{perSeconds:int}/ {seconds:int}/ {fileName}",
                defaults: new
                {
                    controller = "Save",action = "Saver",ip = UrlParameter.Optional,port = UrlParameter.Optional,
                    perSec = UrlParameter.Optional,seconds = UrlParameter.Optional,fileName = UrlParameter.Optional }
            );
        }
    }
}
