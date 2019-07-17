using Administrator.App_Start;
using Administrator.Manager.Implementations;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System.Security.Claims;
using System.Threading;
using Administrator.Manager.Helpers;
using System.Collections.Generic;

namespace Administrator.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    public class CatalogsController : Controller
    {
        private ReadAllGroupImp objReadGroup;
        private ReadGroupImp objReadOnlyGroup;
        private ReadAllUserImp objReadUser;
        private ReadUserImp objReadOnlyUser;
        private ReadGroupUserImp objReadGroupUser;

        public CatalogsController()
        {
            objReadGroup = new ReadAllGroupImp();
            objReadOnlyGroup = new ReadGroupImp();
            objReadUser = new ReadAllUserImp();
            objReadOnlyUser = new ReadUserImp();
            objReadGroupUser = new ReadGroupUserImp();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Inician los controladores del grupo

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

            return View("Index");
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

        public ActionResult ViwerUsers(string sortOrder, string searchString, string currentFilter, int? page)
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

                var salida = objReadUser.ReadAllUser(sortOrder, searchString);
                int pageSize = 10;
                int pageNumber = (page ?? 1);

                return View(salida.ToPagedList(pageNumber, pageSize));
            }
            
            return View("Index");
        }

        [HttpGet]
        public ActionResult PartialViewUserF(int Id, string Tipo)
        {
            ViewBag.groupUser = objReadGroupUser.ReadGroupUser();
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