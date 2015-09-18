using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class LoadDeviceMapRecordListBP
    {
        private List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> DoExtend()
        {
            DateTime dtBegin = new DateTime(this.Date.Year, this.Date.Month, 1);
            DateTime dtEnd = dtBegin.AddMonths(1).AddDays(-1);
            string hql = "(BeginTime>=${0}$ and BeginTime <=${1}$ or EndTime >=${0}$ and EndTime <=${1}$) ";
            hql += " and Device=${2}$ order by BeginTime desc";
            List<object> paramList = new List<object>();
            paramList.Add(dtBegin);
            paramList.Add(dtEnd.AddDays(1));
            paramList.Add(this.DeviceKey);
            List<LabSystemBE.Deploy.DeviceUseRecordDTO> deviceRecordDTOList = new List<LabSystemBE.Deploy.DeviceUseRecordDTO>();
            List<THU.LabSystemBE.DeviceUseRecord> deviceRecordList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.DeviceUseRecord deviceRecord in deviceRecordList)
            {
                deviceRecordDTOList.Add(deviceRecord.ToDTO());
            }

            return deviceRecordDTOList;
        }
    }
}
