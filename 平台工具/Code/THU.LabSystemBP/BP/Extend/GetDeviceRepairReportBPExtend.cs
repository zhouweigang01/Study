using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceRepairReportBP
    {
        private THU.LabSystemBE.Deploy.DeviceRepairReportExDTO DoExtend()
        {
            string hql = "";
            List<object> paramList = new List<object>();
            THU.LabSystemBE.Deploy.DeviceRepairReportExDTO reportExDTO = new LabSystemBE.Deploy.DeviceRepairReportExDTO();
            if (this.Level == 0)
            {
                hql = "IsDelete=0";
                List<THU.LabSystemBE.DeviceMap> deviceMapList = THU.LabSystemBE.DeviceMap.Finder.FindAll(hql, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
                reportExDTO.ListCount = (NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.DeviceMap>(hql, paramList) ?? 0);
                foreach (THU.LabSystemBE.DeviceMap deviceMap in deviceMapList)
                {

                    hql = "CompleteDate>=${0}$ and CompleteDate<=${1}$ and Device=${2}$";
                    paramList.Clear();
                    paramList.Add(this.StartTime);
                    paramList.Add(this.EndTime.AddDays(1));
                    paramList.Add(deviceMap.ID);
                    int total = (NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.DeviceRepairRecord>(hql, paramList) ?? 0);
                    decimal totalFee = NHExt.Runtime.Query.EntityFinder.Sum<THU.LabSystemBE.DeviceRepairRecord>("Fee", hql, paramList) ?? 0;
                    hql = "BizDate>=${0}$ and BizDate<=${1}$ and Device=${2}$ and Status=4";
                    total += (NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.DeviceLog>(hql, paramList) ?? 0);

                    THU.LabSystemBE.Deploy.DeviceRepairReportDTO reportDTO = new LabSystemBE.Deploy.DeviceRepairReportDTO();
                    reportDTO.DeviceKey = deviceMap.ID;
                    reportDTO.DeviceName = deviceMap.Device.Name;
                    reportDTO.SN = deviceMap.SN;
                    reportDTO.HouseName = deviceMap.House.Name;
                    reportDTO.Number = total;
                    reportDTO.Fee = totalFee;
                    reportExDTO.ListData.Add(reportDTO);

                }
            }
            else
            {
                hql = "CompleteDate>=${0}$ and CompleteDate<=${1}$ and Device=${2}$ order by CompleteDate asc";
                paramList.Clear();
                paramList.Add(this.StartTime);
                paramList.Add(this.EndTime.AddDays(1));
                paramList.Add(this.DeviceKey);
                List<THU.LabSystemBE.DeviceRepairRecord> repairList = THU.LabSystemBE.DeviceRepairRecord.Finder.FindAll(hql, paramList);

                hql = "BizDate>=${0}$ and BizDate<=${1}$ and Device=${2}$ and Status=4";

                List<THU.LabSystemBE.DeviceLog> loggerList = THU.LabSystemBE.DeviceLog.Finder.FindAll(hql, paramList);

                foreach (THU.LabSystemBE.DeviceRepairRecord repair in repairList)
                {
                    THU.LabSystemBE.Deploy.DeviceRepairReportDTO reportDTO = new LabSystemBE.Deploy.DeviceRepairReportDTO();
                    reportDTO.DeviceName = repair.Device.Device.Name;
                    // reportDTO.SN = repair.Device.SN;
                    reportDTO.HouseName = repair.House.Name;
                    //  reportDTO.Number = 1;
                    reportDTO.StartTime = (repair.CompleteDate ?? DateTime.Now).ToString("yyyy-MM-dd");
                    reportDTO.Fee = repair.Fee ?? 0;
                    reportDTO.Memo = repair.ReportMemo;
                    reportDTO.RepairMemo = repair.RepairMemo;
                    reportExDTO.ListData.Add(reportDTO);
                }

                foreach (THU.LabSystemBE.DeviceLog logger in loggerList)
                {
                    THU.LabSystemBE.Deploy.DeviceRepairReportDTO reportDTO = new LabSystemBE.Deploy.DeviceRepairReportDTO();
                    reportDTO.DeviceName = logger.Device.Device.Name;
                    // reportDTO.SN = repair.Device.SN;
                    reportDTO.HouseName = logger.Device.House.Name;
                    //  reportDTO.Number = 1;
                    reportDTO.StartTime = logger.BizDate.ToString("yyyy-MM-dd");
                    reportDTO.Memo = "";
                    reportDTO.RepairMemo = "…Ë±∏±®∑œ";
                    reportExDTO.ListData.Add(reportDTO);
                }
                reportExDTO.ListCount = reportExDTO.ListData.Count;
            }
            return reportExDTO;

        }
    }
}
