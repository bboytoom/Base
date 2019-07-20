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
            ViewBag.groupUser = objReadGroupUser.ReadGroupUser();
            ViewBag.userType = HCatalogs.GetTypeUser();

            return View("CreateUsers");
        }

        [HttpGet]
        public ActionResult UpdateUsers(int Id)
        {
            ViewBag.groupUser = objReadGroupUser.ReadGroupUser();
            ViewBag.userType = HCatalogs.GetTypeUser();

            var usuario = objReadOnlyUser.ReadUser(Id);
            return View("CreateUsers", usuario);
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