using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class LoadDeviceUseDiagramBP
    {
        private List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO> useDiagramDTOList = new List<LabSystemBE.Deploy.DeviceUseDiagramDTO>();
            DateTime dtBegin = new DateTime(this.Year, this.Month, 1);
            DateTime dtEnd = dtBegin.AddMonths(1).AddDays(-1);
            string hql = string.Empty;
            if (!this.IsAppoint)
            {
                hql += "BeginTime>=${0}$ and BeginTime<=${1}$ or EndTime>=${0}$ and EndTime<=${1}$ or BeginTime<=${0}$ and EndTime>=${1}$ or BeginTime<=${1}$ and EndTime is null";
            }
            else
            {
                hql += "BeginTime>=${0}$ and BeginTime<=${1}$ and IsAppoint=1";
            }
            List<object> paramList = new List<object>();
            DateTime dt = dtBegin;
            while (dt <= dtEnd)
            {
                paramList.Clear();
                paramList.Add(dt);
                paramList.Add(dt.AddDays(1).AddSeconds(-1));

                THU.LabSystemBE.Deploy.DeviceUseDiagramDTO useDiagramDTO = new LabSystemBE.Deploy.DeviceUseDiagramDTO();

                useDiagramDTO.Date = dt.ToString("yyyy/MM/dd");
                useDiagramDTO.TotalHours = 0;//NHExt.Runtime.Query.EntityFinder.Sum<THU.LabSystemBE.DeviceUseRecord>("TotalTime", hql, paramList) ?? 0;
                useDiagramDTO.TotalFee = 0;//NHExt.Runtime.Query.EntityFinder.Sum<THU.LabSystemBE.DeviceUseRecord>("Fee", hql, paramList) ?? 0;
                useDiagramDTO.ListData = new List<LabSystemBE.Deploy.DeviceUseRecordDTO>();

                List<THU.LabSystemBE.DeviceUseRecord> useRecordList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql + " order by BeginTime", paramList);

                foreach (THU.LabSystemBE.DeviceUseRecord useRecord in useRecordList)
                {

                    if (!this.IsAppoint)
                    {
                        if (DateTime.Now > dt)
                        {
                            DateTime bt = (useRecord.BeginTime < dt ? dt : useRecord.BeginTime);
                            DateTime et = dt.AddDays(1);
                            if (et > DateTime.Now)
                            {
                                et = DateTime.Now;
                            }
                            if (useRecord.EndTime != null)
                            {
                                et = (useRecord.EndTime.Value > et ? et : useRecord.EndTime.Value);
                            }
                            if (et >= bt)
                            {
                                decimal hours = Math.Round(Convert.ToDecimal((et - bt).TotalHours), 2);
                                ///所有费用需要重新计算
                                useDiagramDTO.TotalHours += hours;
                                useDiagramDTO.TotalFee += Math.Round(hours * useRecord.Price, 2);
                            }
                        }
                    }
                    else
                    {
                        useDiagramDTO.ListData.Add(useRecord.ToDTO());
                    }
                }
                if (useDiagramDTO.ListData.Count > 0 || !this.IsAppoint)
                {
                    useDiagramDTOList.Add(useDiagramDTO);
                }

                dt = dt.AddDays(1);
            }
            return useDiagramDTOList;

        }
    }
}
