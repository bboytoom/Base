using System.Web.Mvc;

namespace Administrator.Areas.Super
{
    public class SuperAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Super";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "panel_super",
                "super/panel",
                new { Controller = "Panel", action = "Index" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "catalogs_super",
                "super/catalogo",
                new { Controller = "Catalogs", action = "Index" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "usuarios_super",
                "super/usuarios",
                new { Controller = "Catalogs", action = "ViwerUsers" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "crearusuarios_super",
                "super/usuarios/crear",
                new { Controller = "Catalogs", action = "CreateUsers" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "editusuarios_super",
                "super/usuarios/edit/{Id}",
                new { Controller = "Catalogs", action = "UpdateUsers", Id = UrlParameter.Optional },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "deleteusuarios_super",
                "super/usuarios/delete/{Id}",
                new { Controller = "Catalogs", action = "DeleteUsers", Id = UrlParameter.Optional },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );
        }
    }
}