using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class ToolsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}