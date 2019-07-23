using System.Web.Mvc;

namespace Administrator.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            #region Inician las rutas generales

            context.MapRoute(
                "panel_client",
                "client/panel",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Administrator.Areas.Client.Controllers" }
            );

            #endregion

            #region Inician las ViewPartial

            context.MapRoute(
                "header_client",
                "headerclient",
                new { Controller = "Shared", action = "SharedHeader" },
                namespaces: new[] { "Administrator.Areas.Client.Controllers" }
            );

            #endregion
        }
    }
}