using Administrator.App_Start;
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
        private ReadGroupUserImp objReadGroupUser;
        private ReadUserImp objReadOnlyUser;
        private UpdateSuperImp objUpdateUser;
        private CreateSuperImp objCreateUser;
        private DeleteUserSuperImp objDeleteUser;
        public CatalogsController()
        {
            objAllUSuper = new ReadAllSuperImp();
            objReadGroupUser = new ReadGroupUserImp();
            objReadOnlyUser = new ReadUserImp();
            objUpdateUser = new UpdateSuperImp();
            objCreateUser = new CreateSuperImp();
            objDeleteUser = new DeleteUserSuperImp();
        }

        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(permission = "Read_user_permission")]
        public ActionResult ViwerUsers(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();
                string id_usuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;

                ViewBag.CurrentFilter = searchString;

                var salida = objAllUSuper.ReadAllUser(sortOrder, searchString, Convert.ToInt32(id_usuario));
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                return View(salida.ToPagedList(pageNumber, pageSize));
            }

            return View("Index");
        }

        [HttpGet]
        [CustomAuthorize(permission = "Create_user_permission")]
        public ActionResult CreateUsers()
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();
                string id_usuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                ViewBag.groupUser = objReadGroupUser.ReadGroupUser(Convert.ToInt32(id_usuario));
                ViewBag.userType = HCatalogs.GetTypeUserSuper();
                ViewBag.passWor = "si";

                return View("CreateUsers");
            }

            return View("Index");
        }

        [HttpGet]
        [CustomAuthorize(permission = "Update_user_permission")]
        public ActionResult UpdateUsers(int Id)
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();
                string id_usuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                ViewBag.groupUser = objReadGroupUser.ReadGroupUser(Convert.ToInt32(id_usuario));
                ViewBag.userType = HCatalogs.GetTypeUserSuper();
                ViewBag.passWor = "no";

                return View("CreateUsers", objReadOnlyUser.ReadUser(Id));
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsers(ViewModelUser Data)
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();
                string HieghUser = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                string MainUser = Claims.FirstOrDefault(x => x.Type == "MainUser").Value;

                if (Data.Id == 0)
                {
                    objCreateUser.UserSuper(Data, HieghUser, MainUser);
                }
                else
                {
                    objUpdateUser.UserSuper(Data, HieghUser, MainUser);
                }
            }

            return View();
        }

        [HttpGet]
        [CustomAuthorize(permission = "Delete_user_permission")]
        public ActionResult DeleteUsers(int Id)
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();
                string HieghUser = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                objDeleteUser.DeleteUserSuper(Id, HieghUser);
            }

            return View();
        }
    }
}