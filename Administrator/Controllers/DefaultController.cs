using GestionUsuarios.Helpers;
using GestionUsuarios.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    public class DefaultController : Controller
    {
        private LoginImp objLogin;
        public DefaultController() {
            objLogin = new LoginImp();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ViewModelsLogin data, string returnUrl)
        {
            ActionResult Result;
            string email_clean;

            if (data.Email == null || data.Password == null)
            {
                return Json(new OutJsonCheck
                {
                    Status = 400,
                    Respuesta = false
                });
            }

            if (data.Email == "" || data.Password == "")
            {
                return Json(new OutJsonCheck
                {
                    Status = 400,
                    Respuesta = false
                });
            }

            email_clean = WebUtility.HtmlEncode(data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
            {
                return Json(new OutJsonCheck
                {
                    Status = 415,
                    Respuesta = false
                });
            }

            if (objLogin.Login(data) == null)
                Result = View();
            else
                Result = SingInUser(data, data.Rememberme, returnUrl);

            return Result;
        }

        private ActionResult SingInUser(ViewModelsLogin objetcModel, bool Rememberme, string returnUrl)
        {
            return View();
        }
    }
}