using Administrator.App_Start;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class GroupsController : Controller
    {
        public GroupsController()
        {

        }

        [CustomAuthorize(permission = "Read_group_permission")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PartialViewGroup(int Id, string Tipo)
        {
            return PartialView();
        }
    }
}