using Administrator.App_Start;
using Administrator.Manager.Helpers;
using Administrator.Manager.Implementations;
using PagedList;
using System;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class CatalogsController : Controller
    {
        private ReadAllGroupImp objReadGroup;
        private ReadGroupImp objReadOnlyGroup;
        private ReadAllUserImp objReadUser;
        private ReadUserImp objReadOnlyUser;

        public CatalogsController()
        {
            objReadGroup = new ReadAllGroupImp();
            objReadOnlyGroup = new ReadGroupImp();
            objReadUser = new ReadAllUserImp();
            objReadOnlyUser = new ReadUserImp();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Inician los controladores del grupo

        [CustomAuthorize(permission = "Read_group_permission")]
        public ActionResult ViwerGroups(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var salida = objReadGroup.ReadAllGroup(sortOrder, searchString, Convert.ToInt32(TempData["id_user"]));
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult PartialViewGroupF(int Id, string Tipo)
        {
            if (Id != 0 && Tipo == "actualizar")
            {
                var grupos = objReadOnlyGroup.ReadGroup(Id);
                return PartialView("_PartialViewGroupF", grupos);
            }

            return PartialView("_PartialViewGroupF");
        }

        #endregion

        #region Inician los controladores del usuario

        [CustomAuthorize(permission = "Read_user_permission")]
        public ActionResult ViwerUsers(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var salida = objReadUser.ReadAllUser(sortOrder, searchString, Convert.ToInt32(TempData["id_user"]));
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult PartialViewUserF(int Id, string Tipo, int Main)
        {
            ViewBag.groupUser = ReadGroupUserImp.ReadGroupUser(Main);
            ViewBag.userType = HCatalogs.GetTypeUser();

            if (Id != 0 && Tipo == "actualizar")
            {
                var usuario = objReadOnlyUser.ReadUser(Id);
                return PartialView("_PartialViewUserF", usuario);
            }

            ViewBag.defaultImg = "default.png";
            return PartialView("_PartialViewUserF");
        }

        #endregion
    }
}