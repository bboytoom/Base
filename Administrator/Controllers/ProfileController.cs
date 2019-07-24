using Administrator.Manager.Implementations;
using System;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class ProfileController : Controller
    {
        private ReadUserImp objReadOnlyUser;

        public ProfileController()
        {
            objReadOnlyUser = new ReadUserImp();
        }

        public ActionResult Index()
        {
            var usuario = objReadOnlyUser.ReadUser(Convert.ToInt32(TempData["id_user"]));
            return View("Index", usuario);
        }
    }
}