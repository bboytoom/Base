using Administrator.App_Start;
using Administrator.Manager.Helpers;
using Administrator.Manager.Implementations;
using PagedList;
using System;
using System.Web.Mvc;

namespace Administrator.Areas.Super.Controllers
{
    [Authorize(Roles = "Root,Staff")]
    public class UsersController : Controller
    {
        private ReadUserImp objReadOnlyUser;
        private UpdateSuperImp objUpdateUser;
        private CreateSuperImp objCreateUser;
        private DeleteUserSuperImp objDeleteUser;

        public UsersController()
        {
            objReadOnlyUser = new ReadUserImp();
            objUpdateUser = new UpdateSuperImp();
            objCreateUser = new CreateSuperImp();
            objDeleteUser = new DeleteUserSuperImp();
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
        [CustomAuthorize(permission = "Create_user_permission")]
        public ActionResult CreateUsers()
        {
            ViewBag.groupUser = ReadGroupUserImp.ReadGroupUser(Convert.ToInt32(TempData["id_user"]));
            ViewBag.userType = HCatalogs.GetTypeUserSuper();
            ViewBag.passWor = "si";

            return View("CreateUsers");
        }

        [HttpGet]
        [CustomAuthorize(permission = "Update_user_permission")]
        public ActionResult UpdateUsers(int Id)
        {
            ViewBag.groupUser = ReadGroupUserImp.ReadGroupUser(Convert.ToInt32(TempData["id_user"]));
            ViewBag.userType = HCatalogs.GetTypeUserSuper();
            ViewBag.passWor = "no";

            return View("CreateUsers", objReadOnlyUser.ReadUser(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsers(ViewModelUser Data)
        {
            if (Data.Id == 0)
            {
                objCreateUser.UserSuper(Data, Convert.ToInt32(TempData["id_user"]), Convert.ToInt32(TempData["main_user"]));
            }
            else
            {
                objUpdateUser.UserSuper(Data, Convert.ToInt32(TempData["id_user"]), Convert.ToInt32(TempData["main_user"]));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [CustomAuthorize(permission = "Delete_user_permission")]
        public ActionResult DeleteUsers(int Id)
        {
            objDeleteUser.DeleteUserSuper(Id, Convert.ToInt32(TempData["main_user"]));
            return RedirectToAction("Index");
        }
    }
}