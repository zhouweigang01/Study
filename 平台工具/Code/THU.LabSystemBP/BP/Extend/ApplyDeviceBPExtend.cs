using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ApplyDeviceBP
    {
        private THU.LabSystemBE.Deploy.DeviceUseRecordDTO DoExtend()
        {
            THU.LabSystemBE.DeviceMap deviceMap = THU.LabSystemBE.DeviceMap.Finder.FindById(this.ID);
            if (deviceMap == null)
            {
                throw new Exception("当前设备信息不存在:" + this.ID);
            }

            THU.LabSystemBE.DeviceUseRecord dvRecord = THU.LabSystemBE.DeviceUseRecord.Create();
            dvRecord.Device = deviceMap;
            dvRecord.BeginTime = DateTime.Now;
            dvRecord.UserKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            deviceMap.UseStatus = THU.LabSystemBE.UseStatusEnum.Use;
            NHExt.Runtime.Session.Session.Current.Commit();

            return dvRecord.ToDTO();
        }
    }
}
