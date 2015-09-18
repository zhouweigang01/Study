using System.Web.Mvc;

namespace THU.LabSystem.Areas.User
{
    public class UserAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.IgnoreRoute("User/{controller}/{action}/action.ashx");
            context.Routes.IgnoreRoute("User/{controller}/action.ashx");
            context.Routes.IgnoreRoute("User/action.ashx");
            context.MapRoute(
                "User_default",
                "User/{controller}/{action}/{id}",
                new { controller = "UserConsole", action = "Main", id = UrlParameter.Optional }
            );
        }
    }
}
