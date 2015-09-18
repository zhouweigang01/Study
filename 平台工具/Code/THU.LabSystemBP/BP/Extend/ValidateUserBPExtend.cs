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
                        // throw new Exception("��ǰ�û��˻���û�е�����ʱ�䣬��¼ʧ��");
                        errorMsg = "��ǰ�û��˻���û�е�����ʱ��";
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
                    errorMsg = "����¼�����";
                }
            }
            //��ѯ�Ƿ��гͷ���¼

            hql = "User=${0}$ and StartTime<=${1}$ and EndTime>=${1}$";
            paramList.Clear();
            paramList.Add(usr.ID);
            paramList.Add(DateTime.Now.Date);
            THU.LabSystemBE.ForbidUser forbidUser = THU.LabSystemBE.ForbidUser.Finder.Find(hql, paramList);
            if (forbidUser != null)
            {
                errorMsg = "�㱻����Ա�ڡ�" + forbidUser.StartTime.ToString("yyyy-MM-dd") + "������" + forbidUser.EndTime.ToString("yyyy-MM-dd") + "��֮���ֹ��½ϵͳ";
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
                //�жϵ�ǰ�Ƿ��ǵ�һ�ε�½

                int count = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.User>("1=1") ?? 0;
                if (count == 0)
                {
                    using (NHExt.Runtime.Session.Session session = NHExt.Runtime.Session.Session.New())
                    {
                        usr = THU.LabSystemBE.User.Create();
                        usr.Code = this.Code;
                        usr.Password = this.Password;
                        usr.Name = "ϵͳ����Ա";
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
