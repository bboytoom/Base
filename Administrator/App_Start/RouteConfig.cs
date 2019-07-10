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


            #region Inician las rutas generales

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
                name: "perfil",
                url: "perfil",
                defaults: new { controller = "Profile", action = "Index" }
            );

            routes.MapRoute(
                name: "catalogos",
                url: "catalogos",
                defaults: new { controller = "Catalogs", action = "Index" }
            );

            routes.MapRoute(
                name: "herramientas",
                url: "herramientas",
                defaults: new { controller = "Tools", action = "Index" }
            );

            routes.MapRoute(
                name: "grupos",
                url: "catalogos/grupos",
                defaults: new { controller = "Catalogs", action = "ViwerGroups" }
            );
            
            routes.MapRoute(
                name: "usuarios",
                url: "catalogos/usuarios",
                defaults: new { controller = "Catalogs", action = "ViwerUsers" }
            );

            #endregion

            #region Inician las funcion

            routes.MapRoute(
                name: "salir",
                url: "salir",
                defaults: new { controller = "Default", action = "LogOff" }
            );

            routes.MapRoute(
                name: "bloqueado",
                url: "bloqueado",
                defaults: new { controller = "Default", action = "AttempsLogin" }
            );

            routes.MapRoute(
                name: "lockout",
                url: "lockout",
                defaults: new { controller = "Default", action = "LockOutLogin" }
            );

            #endregion

            #region Inician las ViewPartial

            routes.MapRoute(
                name: "script",
                url: "script",
                defaults: new { controller = "Shared", action = "MScrips" }
            );

            routes.MapRoute(
                name: "groupform",
                url: "grupos/form",
                defaults: new { controller = "Catalogs", action = "PartialViewGroupF" }
            );

            routes.MapRoute(
                name: "userform",
                url: "usuarios/form",
                defaults: new { controller = "Catalogs", action = "PartialViewUserF" }
            );

            routes.MapRoute(
                name: "readgroup",
                url: "grupos/read",
                defaults: new { controller = "Catalogs", action = "ReadViewGroup" }
            );

            #endregion

        }
    }
}
