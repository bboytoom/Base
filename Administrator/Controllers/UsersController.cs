using Administrator.App_Start;
using Administrator.Manager.Helpers;
using Administrator.Manager;
using PagedList;
using System;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class UsersController : Controller
    {
        private ReadUserImp objReadOnlyUser;

        public UsersController()
        {
            objReadOnlyUser = new ReadUserImp();
        }

        [CustomAuthorize(permission = "Read_user_permission")]
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var salida = objReadOnlyUser.ReadAllUser(sortOrder, searchString, Convert.ToInt32(TempData["id_user"]));
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salida.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult PartialViewUser(int Id, string Tipo, int Main)
        {
            ViewBag.groupUser = ReadGroupUserImp.ReadGroupUser(Main);
            ViewBag.userType = HCatalogs.GetTypeUser();

            if (Id != 0 && Tipo == "actualizar")
            {
                var usuario = objReadOnlyUser.ReadUser(Id);
                return PartialView("_PartialViewUser", usuario);
            }

            ViewBag.defaultImg = "default.png";
            return PartialView("_PartialViewUser");
        }
    }
}