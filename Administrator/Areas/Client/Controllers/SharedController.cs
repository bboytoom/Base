using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;

namespace Administrator.Areas.Client.Controllers
{
    public class SharedController : Controller
    {
        [ChildActionOnly]
        public ActionResult SharedHeader()
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();

                TempData["id_user"] = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                TempData["email_user"] = Claims.FirstOrDefault(x => x.Type == "Email").Value;
                TempData["photo_user"] = Claims.FirstOrDefault(x => x.Type == "PhotoUser").Value;

                if (Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Administrador")
                {
                    TempData["main_user"] = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                }
                else
                {
                    TempData["main_user"] = Claims.FirstOrDefault(x => x.Type == "MainUser").Value;
                }
            }

            return PartialView("_Header");
        }
    }
}