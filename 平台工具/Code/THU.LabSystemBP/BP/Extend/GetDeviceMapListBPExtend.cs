using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceMapListBP
    {
        private List<THU.LabSystemBE.Deploy.DeviceMapDTO> DoExtend()
        {
            string hql = "Device=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.DeviceKey);
            List<THU.LabSystemBE.Deploy.DeviceMapDTO> deviceMapDTOList = new List<LabSystemBE.Deploy.DeviceMapDTO>();
            List<THU.LabSystemBE.DeviceMap> deviceMapList = THU.LabSystemBE.DeviceMap.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.DeviceMap deviceMap in deviceMapList)
            {
                deviceMapDTOList.Add(deviceMap.ToDTO());
            }
            return deviceMapDTOList;
        }
    }
}
