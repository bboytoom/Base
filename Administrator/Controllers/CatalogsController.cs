using Administrator.App_Start;
using Administrator.Manager.Implementations;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System.Security.Claims;
using System.Threading;

namespace Administrator.Controllers
{
    [CustomAuthorize]
    public class CatalogsController : Controller
    {
        private ReadAllGroupImp objReadGroup;
        private ReadAllUserImp objReadUser;
        public CatalogsController()
        {
            objReadGroup = new ReadAllGroupImp();
            objReadUser = new ReadAllUserImp();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViwerGroups(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();

                ViewBag.IdUsuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;

                ViewBag.CurrentFilter = searchString;

                var salida = objReadGroup.ReadAllGroup(sortOrder, searchString);
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                return View(salida.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult PartialViewGroupF()
        {
            return PartialView("_PartialViewGroupF");
        }

        public ActionResult ViwerUsers(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            
            ViewBag.CurrentFilter = searchString;

            var salida = objReadUser.ReadAllUser(sortOrder, searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }
    }
}