using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetAllDeviceMapBP
    {
        private THU.LabSystemBE.Deploy.DeviceMapExDTO DoExtend()
        {
            string hql = "1=1";

            List<object> paramList = new List<object>();
            if (this.UseStatus > 0)
            {
                hql += " and (UseStatus=${" + paramList.Count + "}$ or Device.Type=2)";
                paramList.Add(this.UseStatus);
            }
            if (this.DeviceStatus > 0)
            {
                hql += " and DeviceStatus=${" + paramList.Count + "}$ ";
                paramList.Add(this.DeviceStatus);
            }
            THU.LabSystemBE.Deploy.DeviceMapExDTO deviceMapExDTO = new LabSystemBE.Deploy.DeviceMapExDTO();
            deviceMapExDTO.ListData = new List<LabSystemBE.Deploy.DeviceMapDTO>();

            List<THU.LabSystemBE.DeviceMap> deviceMapList = THU.LabSystemBE.DeviceMap.Finder.FindAll(hql, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
            foreach (THU.LabSystemBE.DeviceMap deviceMap in deviceMapList)
            {
                deviceMapExDTO.ListData.Add(deviceMap.ToDTO());
            }
            deviceMapExDTO.ListCount = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.DeviceMap>(hql, paramList) ?? 0;
            return deviceMapExDTO;
        }
    }
}
