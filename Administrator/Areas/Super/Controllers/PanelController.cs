using Administrator.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Areas.Super.Controllers
{
    [Authorize(Roles ="Root,Staff")]
    public class PanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}