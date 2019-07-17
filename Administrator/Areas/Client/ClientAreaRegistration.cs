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
            context.MapRoute(
                "panel_client",
                "client/panel",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}