using Administrator.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}