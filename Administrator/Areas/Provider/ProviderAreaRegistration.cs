using System.Web.Mvc;

namespace Administrator.Areas.Provider
{
    public class ProviderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Provider";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            #region Inician las rutas generales

            context.MapRoute(
                "panel_provider",
                "provider/panel",
                new { Controller = "Panel", action = "Index" },
                namespaces: new[] { "Administrator.Areas.Provider.Controllers" }
            );

            #endregion

            #region Inician las ViewPartial

            context.MapRoute(
                "header_provider",
                "headerprovider",
                new { Controller = "Shared", action = "SharedHeader" },
                namespaces: new[] { "Administrator.Areas.Provider.Controllers" }
            );

            #endregion
        }
    }
}