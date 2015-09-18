using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetUserDeviceMapRecordBP
    {
        private List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> DoExtend()
        {
            string hql = "User=${0}$ and IsCompleted=0";
            List<object> paramList = new List<object>();
            paramList.Add(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (this.IsAppoint)
            {
                hql += " and IsAppoint=1 and EndTime >=${1}$";
                paramList.Add(DateTime.Now);
            }
            else
            {
                hql += " and IsUsing=1";
            }

            hql += " order by ID desc";
     
  
            List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> deviceUseDTOList = new List<LabSystemBE.Deploy.DeviceUseRecordDTO>();
            List<THU.LabSystemBE.DeviceUseRecord> deviceUseList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.DeviceUseRecord deviceUse in deviceUseList)
            {
                deviceUseDTOList.Add(deviceUse.ToDTO());
            }
            return deviceUseDTOList;
        }
    }
}
