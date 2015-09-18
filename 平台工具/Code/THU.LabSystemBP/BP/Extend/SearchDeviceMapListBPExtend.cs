using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class SearchDeviceMapListBP
    {
        private List<THU.LabSystemBE.Deploy.DeviceMapDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.DeviceMapDTO> deviceMapDTOList = new List<LabSystemBE.Deploy.DeviceMapDTO>();
            if (string.IsNullOrEmpty(this.SearchTxt))
            {
                return deviceMapDTOList;
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
            List<THU.LabSystemBE.DeviceMap> deviceMapList = THU.LabSystemBE.DeviceMap.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.DeviceMap deviceMap in deviceMapList)
            {
                deviceMapDTOList.Add(deviceMap.ToDTO());
            }
            return deviceMapDTOList;
        }
    }
}
