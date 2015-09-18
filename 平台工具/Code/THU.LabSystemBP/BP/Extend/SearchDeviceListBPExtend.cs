using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class SearchDeviceListBP
    {
        private List<THU.LabSystemBE.Deploy.DeviceDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.DeviceDTO> deviceDTOList = new List<LabSystemBE.Deploy.DeviceDTO>();
            if (string.IsNullOrEmpty(this.SearchTxt))
            {
                return deviceDTOList;
            }
            List<object> paramList = new List<object>();
            string hql = "(";
            if (this.AttrubuteList != null)
            {
                foreach (string attr in this.AttrubuteList)
                {
                    hql += attr + " like ${0}$ or ";
                }
                paramList.Add(this.SearchTxt + "%");
            }
            hql += " 1!=1 ) and IsDelete=0";
            List<THU.LabSystemBE.Device> deviceList = THU.LabSystemBE.Device.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.Device device in deviceList)
            {
                deviceDTOList.Add(device.ToDTO());
            }
            return deviceDTOList;
        }
    }
}
