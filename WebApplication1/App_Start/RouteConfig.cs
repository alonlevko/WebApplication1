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
                defaults: new { controller = "Display", action = "Display", }
            );

            routes.MapRoute(
                name: "location",
                url: "{controller}/{ip}/{port}/Location",
                defaults: new
                {
                    controller = "Display",
                    action = "Location",
                }
            );

            routes.MapRoute(
                name: "routh",
                url: "{controller}/{ip}/{port}/{seconds}",
                defaults: new { controller = "Display", action = "DisplayRouth" }
            );
            
            routes.MapRoute(
                name: "save",
                url: "{controller}/{ip}/{port}/{perSeconds}/{seconds}/{fileName}",
                defaults: new
                {
                    controller = "Save",
                    action = "Saver"
                }
            );
        }
    }
}
