using Codenesium.JWTSessionAuth;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Codenesium.Foundation.CommonMVC
{
    /// <summary>
    /// This attribute can be added to any controller method that should be secured
    /// with a session.
    /// </summary>
    public class SecureApiFilter : ActionFilterAttribute
    {
        public SessionManager SessionManager { get; set; }
        public bool SecurityEnabled { get; set; }

        public SecureApiFilter()
        {
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            AbstractSecureApiController controller = (AbstractSecureApiController)actionContext.ControllerContext.Controller;
            IEnumerable<string> values;
            if (this.SecurityEnabled)
            {
                if (actionContext.Request.Headers.TryGetValues("Authorization", out values))
                {
                    string sessionString = values.FirstOrDefault();
                    controller.Session = this.SessionManager.Authenticate(sessionString);
                    if (controller.Session == null)
                    {
                        throw new HttpException(401, "Auth Failed");
                    }
                    else
                    {
                        actionContext.Request.Headers.Add("session", controller.Session.ResponseToken);
                    }
                }
                else
                {
                    throw new HttpException(401, "Auth Failed");
                }
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}