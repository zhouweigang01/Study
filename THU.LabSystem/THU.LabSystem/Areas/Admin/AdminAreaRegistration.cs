using System.Web.Mvc;

namespace THU.LabSystem.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.IgnoreRoute("Admin/{controller}/{action}/action.ashx");
            context.Routes.IgnoreRoute("Admin/{controller}/action.ashx");
            context.Routes.IgnoreRoute("Admin/action.ashx");
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "AdminConsole", action = "Main", id = UrlParameter.Optional }
            );
        }
    }
}
