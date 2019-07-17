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
            context.MapRoute(
                "panel_provider",
                "provider/panel",
                new { Controller = "Panel", action = "Index" }
            );
        }
    }
}