using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class HandleRepairBP
    {
        private bool DoExtend()
        {
            //找到保修记录进行处理
            THU.LabSystemBE.DeviceRepairRecord repairRecord = THU.LabSystemBE.DeviceRepairRecord.Finder.FindById(this.ID);
            if (repairRecord == null)
            {
                throw new Exception("报修记录不存在，处理报修请求错误");
            }
            if (repairRecord.CompleteDate != null)
            {
                throw new Exception("当前设备已经维修完成,操作失败");
            }
            repairRecord.RepairDate = DateTime.Now;
            repairRecord.CompleteUserKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (repairRecord.Device.DeviceStatus != THU.LabSystemBE.DeviceStatusEnum.Discard)
            {
                repairRecord.Device.DeviceStatus = THU.LabSystemBE.DeviceStatusEnum.Maintain;
            }

            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
