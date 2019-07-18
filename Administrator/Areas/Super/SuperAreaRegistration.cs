﻿using System.Web.Mvc;

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
                new { Controller = "Panel", action = "Index" }
            );

            context.MapRoute(
                "catalogs_super",
                "super/catalogo",
                new { Controller = "Catalogs", action = "Index" }
            );
        }
    }
}