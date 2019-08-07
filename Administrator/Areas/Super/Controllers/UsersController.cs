using Administrator.App_Start;
using Administrator.Contract;
using System.Web.Mvc;

namespace Administrator.Areas.Super.Controllers
{
    [Authorize(Roles = "Root,Staff")]
    public class UsersController : Controller
    {
        public UsersController()
        {

        }

        [CustomAuthorize(permission = "Read_user_permission")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorize(permission = "Create_user_permission")]
        public ActionResult CreateUsers()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorize(permission = "Update_user_permission")]
        public ActionResult UpdateUsers(int Id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsers(ViewModelUser Data)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        [CustomAuthorize(permission = "Delete_user_permission")]
        public ActionResult DeleteUsers(int Id)
        {
            return RedirectToAction("Index");
        }
    }
}