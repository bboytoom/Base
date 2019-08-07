using Administrator.Manager;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Administrator.App_Start
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string permission { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            var Claims = Principal.Claims.ToList();
            string id_usuario = Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            if (!PermissionImp.Check(permission, Convert.ToInt32(id_usuario)))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Catalogs",
                    action = "Index"
                }));
            }
        }
    }
}