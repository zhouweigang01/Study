using System.Web.Mvc;

namespace THU.LabSystem.Areas.Super
{
    public class SuperAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Super";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.IgnoreRoute("Super/{controller}/{action}/action.ashx");
            context.Routes.IgnoreRoute("Super/{controller}/action.ashx");
            context.Routes.IgnoreRoute("Super/action.ashx");
            context.MapRoute(
                "Super_default",
                "Super/{controller}/{action}/{id}",
                new { controller = "SuperConsole", action = "Main", id = UrlParameter.Optional }
            );
        }
    }
}
