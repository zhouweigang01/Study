using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertDeviceMapBP
    {
        private THU.LabSystemBE.Deploy.DeviceMapDTO DoExtend()
        {
            THU.LabSystemBE.DeviceMap deviceMap = THU.LabSystemBE.DeviceMap.Create();
            deviceMap.FromDTO(this.DeviceMapDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            //新增设备的时候需要新增一条记录日志
            THU.LabSystemBE.DeviceLog deviceLog = THU.LabSystemBE.DeviceLog.Create();
            deviceLog.Status = THU.LabSystemBE.DeviceStatusEnum.Normal;
            deviceLog.OperatorKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            deviceLog.Device = deviceMap;

            NHExt.Runtime.Session.Session.Current.Commit();

            return deviceMap.ToDTO();
        }
    }
}
