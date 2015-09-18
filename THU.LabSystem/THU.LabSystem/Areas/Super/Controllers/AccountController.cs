
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THU.LabSystem.Areas.Super.Controllers
{

    public class AccountController : Controller
    {
        //
        // GET: /Super/Account/

        public ActionResult LogOn()
        {
            if (AuthExt.AuthExtCookie.IsAuth() && AuthExt.AuthExtCookie.GetRole() == 3)
            {
                return RedirectToAction("Main", "SuperConsole");
            }
            else
            {

                return View("LogOn");
            }
        }
        [HttpPost]
        public ActionResult LogOn(THU.LabSystem.Models.LogOnModel model)
        {
            ViewBag.ErrorMsg = string.Empty;
            if (ModelState.IsValid)
            {
                try
                {
                    NHExt.Runtime.Proxy.AgentInvoker invoker = new NHExt.Runtime.Proxy.AgentInvoker();
                    invoker.AssemblyName = "THU.LabSystemBP.Agent.ValidateUserBPProxy";
                    invoker.DllName = "THU.LabSystemBP.Agent.dll";
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "Code", FieldValue = model.Code });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "Password", FieldValue = NHExt.Runtime.Util.EncryptHelper.Encrypt(model.Password) });
                    invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "Org", FieldValue = 1L });
                    invoker.SourcePage = "IWEHAVE.Login";
                    THU.LabSystemBE.Deploy.UserDTO usrDTO = invoker.Do<THU.LabSystemBE.Deploy.UserDTO>();
                    if (usrDTO == null || usrDTO.Type != THU.LabSystemBE.Deploy.UserTypeEnumDTO.Super.EnumValue)
                    {
                        ViewBag.ErrorMsg = "用户名或密码错误";
                    }
                    else
                    {
                        NHExt.Runtime.GAIA.AuthContext.SetContext(usrDTO.ID, usrDTO.Code, usrDTO.Name, usrDTO.Password, usrDTO.OrgnizationC, usrDTO.Orgnization, string.Empty);
                        THU.LabSystem.AuthExt.AuthExtCookie.SetRole(usrDTO.Type);

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMsg = "用户登录失败，错误原因:" + ex.Message;
                }
            }
            else
            {
                ViewBag.ErrorMsg = "登录数据录入错误";
            }
            if (string.IsNullOrEmpty(ViewBag.ErrorMsg))
            {
                return RedirectToAction("Main", "SuperConsole");
            }
            else
            {
                return View();
            }

        }

    }
}
