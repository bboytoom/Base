using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Areas.Provider.Controllers
{
    [Authorize(Roles = "Proveedor")]
    public class PanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}