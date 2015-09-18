using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ValidateUserBP
    {
        private THU.LabSystemBE.Deploy.UserDTO DoExtend()
        {
            string hql = "(SN=${0}$ or Email=${0}$ or Code=${0}$) and Password=${1}$ and IsDelete=0";
            List<object> paramList = new List<object>();
            paramList.Add(this.Code);
            paramList.Add(this.Password);
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.Find(hql, paramList);
            string errorMsg = string.Empty;
            if (usr != null)
            {
                if (usr.Type == THU.LabSystemBE.UserTypeEnum.User)
                {
                    if (usr.BeginTime > DateTime.Now.Date || usr.EndTime < DateTime.Now.Date)
                    {
                        // throw new Exception("当前用户账户还没有到启用时间，登录失败");
                        errorMsg = "当前用户账户还没有到启用时间";
                    }
                }
            }
            else
            {
                hql = "(SN=${0}$ or Email=${0}$ or Code=${0}$) and IsDelete=0";
                paramList.Clear();
                paramList.Add(this.Code);
                usr = THU.LabSystemBE.User.Finder.Find(hql, paramList);
                if (usr != null)
                {
                    errorMsg = "密码录入错误";
                }
            }
            //查询是否有惩罚记录

            hql = "User=${0}$ and StartTime<=${1}$ and EndTime>=${1}$";
            paramList.Clear();
            paramList.Add(usr.ID);
            paramList.Add(DateTime.Now.Date);
            THU.LabSystemBE.ForbidUser forbidUser = THU.LabSystemBE.ForbidUser.Finder.Find(hql, paramList);
            if (forbidUser != null)
            {
                errorMsg = "你被管理员在“" + forbidUser.StartTime.ToString("yyyy-MM-dd") + "”到“" + forbidUser.EndTime.ToString("yyyy-MM-dd") + "”之间禁止登陆系统";
            }
            if (usr != null)
            {
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    using (NHExt.Runtime.Session.Transaction trans = NHExt.Runtime.Session.Transaction.New(NHExt.Runtime.Enums.TransactionSupport.RequiredNew))
                    {
                        THU.LabSystemBE.LoginLogger logger = THU.LabSystemBE.LoginLogger.Create();
                        logger.User = usr.ID;
                        logger.Name = usr.Name;
                        logger.IP = NHExt.Runtime.Session.SessionCache.Current.AuthContext.RemoteIP;
                        logger.ErrorMsg = errorMsg;
                        logger.LoginDate = DateTime.Now;
                    }
                    usr = null;
                }
            }

            if (usr != null)
            {
                return usr.ToDTO();
            }
            else
            {
                //判断当前是否是第一次登陆

                int count = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.User>("1=1") ?? 0;
                if (count == 0)
                {
                    using (NHExt.Runtime.Session.Session session = NHExt.Runtime.Session.Session.New())
                    {
                        usr = THU.LabSystemBE.User.Create();
                        usr.Code = this.Code;
                        usr.Password = this.Password;
                        usr.Name = "系统管理员";
                        usr.Type = THU.LabSystemBE.UserTypeEnum.Admin;

                        session.Commit();
                    }
                    return usr.ToDTO();
                }
                else
                {
                    if (string.IsNullOrEmpty(errorMsg))
                    {
                        return null;
                    }
                    else
                    {
                        throw new Exception(errorMsg);
                    }
                }
            }
        }
    }
}
