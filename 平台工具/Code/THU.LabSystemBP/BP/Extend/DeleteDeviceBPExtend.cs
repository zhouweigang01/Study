using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteDeviceBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.Device device = THU.LabSystemBE.Device.Finder.FindById(this.ID);
            if (device == null)
            {
                throw new Exception("设备信息不存在");
            }

            string hql = "Device=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.ID);
            List<THU.LabSystemBE.DeviceMap> dmList = THU.LabSystemBE.DeviceMap.Finder.FindAll(hql, paramList);

            hql = "Device.Device=${0}$";
            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);

            if (useRecord != null)
            {
                device.IsDelete = true;
                foreach (THU.LabSystemBE.DeviceMap dm in dmList)
                {
                    DeleteDeviceMapBP bp = new DeleteDeviceMapBP();
                    bp.ID = dm.ID;
                    bp.Do();
                }
            }
            else
            {
                foreach (THU.LabSystemBE.DeviceMap dm in dmList)
                {
                    // NHExt.Runtime.Session.Session.Current.Remove(dm);
                    DeleteDeviceMapBP bp = new DeleteDeviceMapBP();
                    bp.ID = dm.ID;
                    bp.Do();
                }
                NHExt.Runtime.Session.Session.Current.Commit();
                NHExt.Runtime.Session.Session.Current.Remove(device);
            }

            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
