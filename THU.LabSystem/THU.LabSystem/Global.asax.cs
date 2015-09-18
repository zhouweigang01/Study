using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading.Tasks;

namespace THU.LabSystem
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{controller}/{action}/action.ashx");
            routes.IgnoreRoute("{controller}/action.ashx");
            routes.IgnoreRoute("action.ashx");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            NHExt.Runtime.Cfg.Init();

            System.Threading.Tasks.Task tsk = new System.Threading.Tasks.Task(TaskWorker, 3, TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent);
            tsk.Start();
        }


        private static void TaskWorker(object state)
        {
            int nTime = (int)state;
            while (true)
            {
                System.Threading.Thread.Sleep(0);
                try
                {
                    NHExt.Runtime.Proxy.AgentInvoker invoker = new NHExt.Runtime.Proxy.AgentInvoker();
                    invoker.AssemblyName = "THU.LabSystemBP.Agent.SynDeviceMapBPProxy";
                    invoker.DllName = "THU.LabSystemBP.Agent.dll";
                    invoker.Do();

                }
                catch { }
                System.Threading.Thread.Sleep(new TimeSpan(0, 1, 0));

            }
        }
    }
}