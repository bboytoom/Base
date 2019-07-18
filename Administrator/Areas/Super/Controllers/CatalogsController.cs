using Administrator.Manager.Helpers;
using Administrator.Manager.Implementations;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Areas.Super.Controllers
{
    [Authorize(Roles = "Root,Staff")]
    public class CatalogsController : Controller
    {
        private ReadAllSuperImp objAllUSuper;
        public CatalogsController()
        {
            objAllUSuper = new ReadAllSuperImp();
        }

        public ActionResult Index()
        {
            return View();
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

            var salida = objAllUSuper.ReadAllUser(sortOrder, searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult CreateUsers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUsers(ViewModelUser Data)
        {
            return View();
        }
    }
}