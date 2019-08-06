using Administrator.App_Start;
using Administrator.Manager;
using Administrator.Manager.Helpers;
using PagedList;
using System;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class UsersController : Controller
    {
        private UserImp ObjUser;

        public UsersController()
        {
            ObjUser = new UserImp();
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

            var salida = ObjUser.ReadAll(sortOrder, searchString, Convert.ToInt32(TempData["id_user"]));
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
                var usuario = ObjUser.Read(Id);
                return PartialView("_PartialViewUser", usuario);
            }

            ViewBag.defaultImg = "default.png";
            return PartialView("_PartialViewUser");
        }
    }
}