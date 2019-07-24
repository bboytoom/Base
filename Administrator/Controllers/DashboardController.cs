using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}