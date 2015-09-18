using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THU.LabSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthError()
        {
            string key = this.Request.QueryString["key"];
            if (key != "3")
            {
                return RedirectToAction("LogOn", "Home");
            }
            else
            {
                return RedirectToAction("LogOn", "Super/Account");
            }
        }


        public ActionResult LogOn()
        {
            ViewBag.OrgList = null;
            if (AuthExt.AuthExtCookie.IsAuth())
            {
                int role = AuthExt.AuthExtCookie.GetRole();
                if (role == THU.LabSystemBE.Deploy.UserTypeEnumDTO.Admin.EnumValue)
                {
                    return RedirectToAction("Main", "Admin/AdminConsole");

                }
                else if (role == THU.LabSystemBE.Deploy.UserTypeEnumDTO.User.EnumValue)
                {
                    return RedirectToAction("Main", "User/UserConsole");
                }
                else
                {
                    AuthExt.AuthExtCookie.Clear();
                }

            }
            //NHExt.Runtime.Proxy.AgentInvoker invoker = new NHExt.Runtime.Proxy.AgentInvoker();
            //invoker.AssemblyName = "THU.LabSystemBP.Agent.GetOrgListBPProxy";
            //invoker.DllName = "THU.LabSystemBP.Agent.dll";
            //   ViewBag.OrgList = invoker.Do<List<THU.LabSystemBE.Deploy.OrgDTO>>();
            //获取组织数据
            return View();

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
                    // invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = "Org", FieldValue = model.Org });
                    invoker.SourcePage = "IWEHAVE.Login";
                    THU.LabSystemBE.Deploy.UserDTO usrDTO = invoker.Do<THU.LabSystemBE.Deploy.UserDTO>();
                    if (usrDTO == null)
                    {
                        ViewBag.ErrorMsg = "用户名或密码错误";
                    }
                    else
                    {
                        NHExt.Runtime.Auth.AuthContext.SetContext(usrDTO.ID, usrDTO.Code, usrDTO.Name, usrDTO.Password, string.Empty);
                        THU.LabSystem.AuthExt.AuthExtCookie.SetRole(usrDTO.Type);
                        if (usrDTO.Type == THU.LabSystemBE.Deploy.UserTypeEnumDTO.Admin.EnumValue)
                        {
                            return RedirectToAction("Main", "Admin/AdminConsole");

                        }
                        else if (usrDTO.Type == THU.LabSystemBE.Deploy.UserTypeEnumDTO.User.EnumValue)
                        {
                            return RedirectToAction("Main", "User/UserConsole");
                        }
                        else
                        {
                            AuthExt.AuthExtCookie.Clear();
                        }
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

            return LogOn();


        }

        public ActionResult LogOut()
        {
            AuthExt.AuthExtCookie.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
