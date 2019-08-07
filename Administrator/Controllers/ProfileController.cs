using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class ProfileController : Controller
    {
        public ProfileController()
        {

        }

        public ActionResult Index()
        {
            return View("Index");
        }

        #region Acciones del cambio de password

        [HttpGet]
        public JsonResult CheckPassword(int Id, string Password)
        {
            return Json(new { Respuesta = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangePassword(int Id, string PasswordUno, string PasswordDos)
        {
            return Json(new { Respuesta = true }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}