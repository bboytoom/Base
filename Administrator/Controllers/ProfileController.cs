using Administrator.Manager.Helpers;
using Administrator.Manager;
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

        #region Acciones del cambio de password

        [HttpGet]
        public JsonResult CheckPassword(int Id, string Password)
        {
            if (Id == 0 || Password == "")
                return Json(new { Respuesta = false }, JsonRequestBehavior.AllowGet);

            return Json(new { Respuesta = objChekPass.CheckPassword(Id, Password) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangePassword(int Id, string PasswordUno, string PasswordDos)
        {
            if (PasswordUno == "" || PasswordDos == "")
                return Json(new { Respuesta = false }, JsonRequestBehavior.AllowGet);

            if (PasswordUno != PasswordDos)
                return Json(new { Respuesta = false }, JsonRequestBehavior.AllowGet);

            return Json(new { Respuesta = objChekPass.ChangePasswordImp(Id, PasswordUno) }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}