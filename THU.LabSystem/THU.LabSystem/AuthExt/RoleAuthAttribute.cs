using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THU.LabSystem.AuthExt
{
    public class RoleAuthAttribute : AuthorizeAttribute
    {
        public int RoleType { get; private set; }
        public RoleAuthAttribute(int type)
        {
            this.RoleType = type;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            NHExt.Runtime.Auth.AuthContext ctx = NHExt.Runtime.Auth.AuthContext.GetInstance();
            if (ctx.IsAuth())
            {
                int roleType = AuthExtCookie.GetRole();
                if (roleType == this.RoleType)
                {
                    result = true;
                }
            }
            if (!result)
            {
                httpContext.Response.StatusCode = 403;
            }
            return result;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 403)
            {
                filterContext.Result = new RedirectResult("/Home/AuthError/?key=" + this.RoleType);
            }

        }
    }
}