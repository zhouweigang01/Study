using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceListBP
    {
        private THU.LabSystemBE.Deploy.DeviceExDTO DoExtend()
        {
            string hql = "1=1";
            List<object> paramList = new List<object>();
            if (this.Type > 0)
            {
                hql += " and Type=${" + paramList.Count + "}$";
                paramList.Add(this.Type);
            }
            if (this.ID > 0)
            {
                hql += " and ID=${" + paramList.Count + "}$";
                paramList.Add(this.ID);
            }
            THU.LabSystemBE.Deploy.DeviceExDTO deviceExDTO = new LabSystemBE.Deploy.DeviceExDTO();
            deviceExDTO.ListData = new List<LabSystemBE.Deploy.DeviceDTO>();
            List<THU.LabSystemBE.Device> deviceList = THU.LabSystemBE.Device.Finder.FindAll(hql, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
            foreach (THU.LabSystemBE.Device device in deviceList)
            {
                deviceExDTO.ListData.Add(device.ToDTO());
            }
            deviceExDTO.ListCount = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.Device>(hql, paramList) ?? 0;
            return deviceExDTO;
        }
    }
}
