using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Areas.Client.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class PanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}