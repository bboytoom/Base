using Administrator.Manager.Helpers;
using Administrator.Manager.Implementations;
using System;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class ProfileController : Controller
    {
        private ReadUserImp objReadOnlyUser;
        private CheckPasswordImp objChekPass;

        public ProfileController()
        {
            objReadOnlyUser = new ReadUserImp();
            objChekPass = new CheckPasswordImp();
        }

        public ActionResult Index()
        {
            ViewBag.groupUser = ReadGroupUserImp.ReadGroupUser(Convert.ToInt32(TempData["main_user"]));
            ViewBag.userType = HCatalogs.GetTypeUser();

            var usuario = objReadOnlyUser.ReadUser(Convert.ToInt32(TempData["id_user"]));
            return View("Index", usuario);
        }

        [HttpGet]
        public ActionResult ViwerPassword()
        {
            return PartialView("_ChangePassword");
        }

        [HttpGet]
        public JsonResult CheckPassword(int Id, string Password)
        {
            return Json(new { Respuesta = objChekPass.CheckPassword(Id, Password) }, JsonRequestBehavior.AllowGet);
        }
    }
}