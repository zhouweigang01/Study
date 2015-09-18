using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ApplyRepairBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceMap deviceMap = null;
            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.FindById(this.ID);
            if (useRecord == null)
            {
                deviceMap = THU.LabSystemBE.DeviceMap.Finder.FindById(this.ID);
            }
            else
            {
                useRecord.IsCompleted = true;
                //预约设备也可以报修
                //if (!useRecord.IsAppoint)
                //{
                useRecord.EndTime = DateTime.Now;
                // }
                NHExt.Runtime.Session.Session.Current.Commit();
                deviceMap = useRecord.Device;
            }
            if (deviceMap == null)
            {
                throw new Exception("报修设备信息不存在");
            }
            if (deviceMap.DeviceStatus == THU.LabSystemBE.DeviceStatusEnum.Discard)
            {
                throw new Exception("当前设备已经报废，报修失败");
            }
            //设备保修，生成一条报修记录
            THU.LabSystemBE.DeviceRepairRecord repaireRecord = THU.LabSystemBE.DeviceRepairRecord.Create();
            repaireRecord.UserKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            repaireRecord.ReportMemo = this.Memo;
            repaireRecord.Device = deviceMap;
            //报修
            repaireRecord.Device.DeviceStatus = THU.LabSystemBE.DeviceStatusEnum.Fault;
            NHExt.Runtime.Session.Session.Current.Commit();

            return true;

        }
    }
}
