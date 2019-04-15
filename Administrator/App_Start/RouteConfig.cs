using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Administrator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "default",
                url: "",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "dashboard",
                url: "inicio",
                defaults: new { controller = "Dashboard", action = "Index" }
            );

            routes.MapRoute(
                name: "catalogos",
                url: "catalogos",
                defaults: new { controller = "Catalogs", action = "Index" }
            );
        }
    }
}
