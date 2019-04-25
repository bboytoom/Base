using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize]
    public class CatalogsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}