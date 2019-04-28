using GestionUsuarios.Helpers;
using GestionUsuarios.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using GestionUsuarios.Data;

namespace Administrator.Controllers
{
    public class DefaultController : Controller
    {
        private LoginImp objLogin;
        public DefaultController() {
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
        public ActionResult Index(ViewModelsLogin data, string returnUrl)
        {
            ActionResult Result;
            string email_clean;

            if (data.Email == null || data.Password == null)
                return Json(new OutJsonCheck
                {
                    Status = 400,
                    Respuesta = false
                });
            
            if (data.Email == "" || data.Password == "")
                return Json(new OutJsonCheck
                {
                    Status = 400,
                    Respuesta = false
                });
            
            email_clean = WebUtility.HtmlEncode(data.Email.ToLower());

            if (!HCheckEmail.EmailCheck(email_clean))
                return Json(new OutJsonCheck
                {
                    Status = 415,
                    Respuesta = false
                });

            if (objLogin.Login(data) == null)
            {
                if (LockOutUser.InsertAttemps(email_clean))
                {
                    HttpCookie attempCookie = new HttpCookie("_attempts");
                    attempCookie.Value = "bloqueado";
                    attempCookie.Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies.Add(attempCookie);

                    LockOutUser.InsertCycle(email_clean);
                    return RedirectToAction("AttempsLogin", "Default");
                }
                
                ModelState.Clear();
                Result = View();
            }
            else
            {
                Response.Cookies["_attempts"].Expires = DateTime.Now.AddMinutes(-1);
                LockOutUser.ResetAttemps(email_clean);
                Result = SingInUser(objLogin.Login(data), data.Rememberme, returnUrl);
            }

            return Result;
        }

        private ActionResult SingInUser(Tbl_Usuarios objetcModel, bool Rememberme, string returnUrl)
        {
            ActionResult Result;

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, objetcModel.id.ToString()),
                new Claim("fullname", $"{objetcModel.nombre_usuario} {objetcModel.apellidoP_usuario}")
            };

            if (objetcModel.userType_usuario != 0)
            {
                int usetType = objetcModel.userType_usuario;

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
                    case 5:
                        claims.Add(new Claim(ClaimTypes.Role, "Proveedor"));
                        break;
                }
            }

            var Identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = Rememberme }, Identity);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = @Url.Action("Index", "Default");
            }

            Result = RedirectToAction("Index", "Dashboard");

            return Result;
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