using System.Web.Mvc;

namespace Administrator.Areas.Super.Controllers
{
    [Authorize(Roles = "Root,Staff")]
    public class PanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}