using Administrator.Contract;
using Administrator.Manager;
using Administrator.Manager.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    public class DefaultController : Controller
    {
        private LoginImp objLogin;
        public DefaultController()
        {
            objLogin = new LoginImp();
        }

        [OutputCache(Duration = 0)]
        public ActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                if (Request.Cookies["_attempts"] != null)
                    return RedirectToAction("AttempsLogin", "Default");

                if (Request.Cookies["_inactiva"] != null)
                    return RedirectToAction("LockOutLogin", "Default");

                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Index(ViewModelsAuth data)
        {
            JsonResult Result;
            string email_clean;

            if (data.Email == null || data.Password == null)
                return Json(new { Status = 404, Respuesta = "El correo y/o password se encuentran vacios" }, JsonRequestBehavior.AllowGet);

            if (data.Email == "" || data.Password == "")
                return Json(new { Status = 404, Respuesta = "El correo y/o password se encuentran vacios" }, JsonRequestBehavior.AllowGet);

            email_clean = WebUtility.HtmlEncode(data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return Json(new { Status = 415, Respuesta = "Correo electronico no valido" }, JsonRequestBehavior.AllowGet);

            if (!CStatusUser.StatusUser(data.Email))
                return Json(new { Status = 401, Respuesta = "Usuario inactivo, consulte a su administrador" }, JsonRequestBehavior.AllowGet);

            if (objLogin.Login(data) == null)
            {
                if (LockOutUser.InsertAttemps(email_clean))
                {
                    HttpCookie attempCookie = new HttpCookie("_attempts")
                    {
                        Value = "bloqueado",
                        Expires = DateTime.Now.AddMinutes(2)
                    };

                    Response.Cookies.Add(attempCookie);

                    LockOutUser.InsertCycle(email_clean);
                    return Json(new { Status = 403, Respuesta = "Usuario bloqueado temporalmente" }, JsonRequestBehavior.AllowGet);
                }

                ModelState.Clear();
                return Json(new { Status = 203, Respuesta = "La contraseña no es correcta" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Response.Cookies["_attempts"].Expires = DateTime.Now.AddMinutes(-1);
                LockOutUser.ResetAttemps(email_clean);
                Result = SingInUser(objLogin.Login(data), data.Rememberme);
            }

            return Result;
        }

        private JsonResult SingInUser(ViewModelClaims objetcModel, bool Rememberme)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, objetcModel.Identificador),
                new Claim("Fullname", objetcModel.Fullname),
                new Claim("MainUser", objetcModel.MainUser),
                new Claim("Email", objetcModel.Email),
                new Claim("PhotoUser", objetcModel.PhotoUser)
            };

            if (objetcModel.TypeUser != 0)
            {
                int usetType = objetcModel.TypeUser;

                switch (usetType)
                {
                    case 1:
                        claims.Add(new Claim(ClaimTypes.Role, "Root"));
                        break;
                    case 2:
                        claims.Add(new Claim(ClaimTypes.Role, "Staff"));
                        break;
                    case 3:
                        claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
                        break;
                    case 4:
                        claims.Add(new Claim(ClaimTypes.Role, "Usuario"));
                        break;
                }
            }

            var Identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = Rememberme }, Identity);

            return ReturnJson(objetcModel.TypeUser);
        }

        private JsonResult ReturnJson(int tipo)
        {
            return Json(new { Status = 200, Respuesta = tipo }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Default");
        }

        [OutputCache(Duration = 0)]
        public ActionResult AttempsLogin()
        {
            if (Request.Cookies["_attempts"] == null)
                return RedirectToAction("Index", "Default");

            return View();
        }

        [OutputCache(Duration = 0)]
        public ActionResult LockOutLogin()
        {
            if (Request.Cookies["_inactiva"] == null)
                return RedirectToAction("Index", "Default");

            return View();
        }
    }
}