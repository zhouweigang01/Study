using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteAppointBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.FindById(this.ID);
            if (useRecord.IsCompleted)
            {
                throw new Exception("当前记录已经结束，取消申请失败");
            }
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (usr != null)
            {
                if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin && usr.ID != useRecord.User.ID)
                {
                    throw new Exception("当前用户没有修改当前数据的权限");
                }

                NHExt.Runtime.Session.Session.Current.Remove(useRecord);
                NHExt.Runtime.Session.Session.Current.Commit();
            }
            return true;
        }
    }
}
