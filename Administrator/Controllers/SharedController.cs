using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    public class SharedController : Controller
    {
        [ChildActionOnly]
        public ActionResult MScrips()
        {        
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.tipo = "interno";
            }
            else
            {
                ViewBag.tipo = "externo";
            }

            return PartialView("_Scrips");
        }

        public ActionResult MHeader()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.tipo = "interno";
            }
            else
            {
                ViewBag.tipo = "externo";
            }

            return PartialView("_Header");
        }
    }
}