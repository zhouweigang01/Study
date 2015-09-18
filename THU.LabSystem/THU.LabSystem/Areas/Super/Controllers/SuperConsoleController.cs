using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THU.LabSystem.Areas.Super.Controllers
{
    /// <summary>
    /// THU.LabSystemBE.Deploy.UserTypeEnumDTO.Super
    /// </summary>
    [AuthExt.RoleAuth(3)]
    public class SuperConsoleController : Controller
    {
        //
        // GET: /Super/SuperConsole/

        public ActionResult Main()
        {

            return View();
        }
        public ActionResult Org()
        {
            return View();
        }
        public ActionResult OrgUser()
        {
            return View();
        }

    }
}
