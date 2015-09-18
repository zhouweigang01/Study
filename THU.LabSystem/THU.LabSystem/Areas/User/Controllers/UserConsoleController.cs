using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THU.LabSystem.Areas.User.Controllers
{
    /// <summary>
    /// THU.LabSystemBE.Deploy.UserTypeEnumDTO.User
    /// </summary>
    [AuthExt.RoleAuth(1)]
    public class UserConsoleController : Controller
    {
        //
        // GET: /User/UserConsole/

        public ActionResult Main()
        {
            return View();
        }
        public ActionResult DeviceApply()
        {
            return View();
        }
        public ActionResult DeviceAppoint()
        {
            return View();
        }

    }
}
