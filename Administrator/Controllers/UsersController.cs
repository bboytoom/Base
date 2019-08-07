using Administrator.App_Start;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        [CustomAuthorize(permission = "Read_user_permission")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PartialViewUser(int Id, string Tipo, int Main)
        {
            return PartialView();
        }
    }
}