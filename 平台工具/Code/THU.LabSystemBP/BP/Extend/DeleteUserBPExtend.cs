using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteUserBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(this.ID);
            if (usr == null)
            {
                throw new Exception("用户信息不存在");
            }
            string hql = "User=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.ID);
            THU.LabSystemBE.DeviceUseRecord record = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);

            if (record == null)
            {
                NHExt.Runtime.Session.Session.Current.Remove(usr);
            }
            else
            {
                usr.IsDelete = true;
            }
            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
