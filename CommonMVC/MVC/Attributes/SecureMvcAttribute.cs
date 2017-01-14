using Codenesium.JWTSessionAuth;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Codenesium.Foundation.CommonMVC
{
    /// <summary>
    /// This attribute can be added to any controller method that should be secured
    /// with a session.
    /// </summary>
    public class SecureMvcFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public SessionManager SessionManager { get; set; }
        public bool SecurityEnabled { get; set; }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            AbstractSecureController controller = (AbstractSecureController)actionContext.Controller;
            if (this.SecurityEnabled)
            {
                if (actionContext.RequestContext.HttpContext.Request.Cookies.Get("session") != null)
                {
                    string sessionString = actionContext.RequestContext.HttpContext.Request.Cookies.Get("session").Value;
                    controller.Session = this.SessionManager.Authenticate(sessionString);
                    if (controller.Session == null)
                    {
                        throw new HttpException(401, "Auth Failed");
                    }
                    else
                    {
                        actionContext.RequestContext.HttpContext.Response.SetCookie(new HttpCookie("session", controller.Session.ResponseToken));
                    }
                }
                else
                {
                    throw new HttpException(401, "Auth Failed");
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}