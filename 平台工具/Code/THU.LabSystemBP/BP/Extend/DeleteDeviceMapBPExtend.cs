using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteDeviceMapBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceMap dm = THU.LabSystemBE.DeviceMap.Finder.FindById(this.ID);
            if (dm == null)
            {
                throw new Exception("设备信息不存在");
            }

            string hql = "Device=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.ID);
            hql = "Device.Device=${0}$";
            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);

            if (useRecord != null)
            {
                dm.IsDelete = true;

            }
            else
            {
                hql = "Device=${0}$";
                paramList.Clear();
                paramList.Add(this.ID);
                List<THU.LabSystemBE.DeviceLog> logList = THU.LabSystemBE.DeviceLog.Finder.FindAll(hql, paramList);
                foreach (THU.LabSystemBE.DeviceLog log in logList)
                {
                    NHExt.Runtime.Session.Session.Current.Remove(log);
                }
                NHExt.Runtime.Session.Session.Current.Commit();
                NHExt.Runtime.Session.Session.Current.Remove(dm);
            }

            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
