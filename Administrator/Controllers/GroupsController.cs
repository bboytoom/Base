using Administrator.App_Start;
using Administrator.Manager;
using PagedList;
using System;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class GroupsController : Controller
    {
        private ReadGroupImp objReadOnlyGroup;

        public GroupsController()
        {
            objReadOnlyGroup = new ReadGroupImp();
        }

        [CustomAuthorize(permission = "Read_group_permission")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var salida = objReadOnlyGroup.ReadAllGroup(sortOrder, searchString, Convert.ToInt32(TempData["id_user"]));
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult PartialViewGroup(int Id, string Tipo)
        {
            if (Id != 0 && Tipo == "actualizar")
            {
                var grupos = objReadOnlyGroup.ReadGroup(Id);
                return PartialView("_PartialViewGroup", grupos);
            }

            return PartialView("_PartialViewGroup");
        }
    }
}