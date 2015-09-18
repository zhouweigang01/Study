using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceUseReportBP
    {
        private THU.LabSystemBE.Deploy.DeviceUseReportExDTO DoExtend()
        {
            string hql = "";
            DateTime dtEnd = this.EndTime.AddDays(1).AddSeconds(-1);
            List<object> paramList = new List<object>();
            THU.LabSystemBE.Deploy.DeviceUseReportExDTO reportExDTO = new LabSystemBE.Deploy.DeviceUseReportExDTO();
            if (this.Level == 0)
            {
                hql = "IsDelete=0";
                List<THU.LabSystemBE.Teacher> teacherList = THU.LabSystemBE.Teacher.Finder.FindAll(hql, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
                reportExDTO.ListCount = (NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.Teacher>(hql, paramList) ?? 0);
                foreach (THU.LabSystemBE.Teacher teacher in teacherList)
                {
                    hql = "(BeginTime>=${0}$ and BeginTime<=${1}$ or EndTime>=${0}$ and EndTime<=${1}$ or BeginTime<=${0}$ and EndTime>=${1}$ or BeginTime<=${1}$ and EndTime is null)and Teacher=${2}$ ";

                    paramList.Clear();
                    paramList.Add(this.StartTime);
                    paramList.Add(dtEnd);
                    paramList.Add(teacher.ID);

                    if (this.DeviceKey > 0)
                    {
                        hql += " and Device=${" + paramList.Count + "}$";
                        paramList.Add(this.DeviceKey);
                    }


                    THU.LabSystemBE.Deploy.DeviceUseReportDTO reportDTO = new LabSystemBE.Deploy.DeviceUseReportDTO();
                    reportDTO.TeacherKey = teacher.ID;
                    reportDTO.TeacherName = teacher.Name;
                    reportDTO.StartTime = this.StartTime;
                    reportDTO.EndTime = this.EndTime;
                    List<THU.LabSystemBE.DeviceUseRecord> useRecordList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql, paramList);
                    foreach (THU.LabSystemBE.DeviceUseRecord useRecord in useRecordList)
                    {
                        DateTime bt = (useRecord.BeginTime < this.StartTime ? this.StartTime : useRecord.BeginTime);
                        DateTime et = DateTime.Now;
                        if (useRecord.EndTime != null)
                        {
                            if (useRecord.EndTime.Value < dtEnd)
                            {
                                et = useRecord.EndTime.Value;
                            }
                        }
                        if (et > dtEnd)
                        {
                            et = dtEnd;
                        }

                        double hours = (et - bt).TotalHours;
                        if (hours > 0)
                        {
                            reportDTO.Hours += hours;
                            reportDTO.Fee += Convert.ToDecimal(Math.Round(hours, 2)) * useRecord.Price;
                        }
                    }
                    reportDTO.Hours = Math.Round(reportDTO.Hours, 2);
                    reportDTO.Fee = Math.Round(reportDTO.Fee, 2);
                    reportExDTO.ListData.Add(reportDTO);
                }
            }
            else
            {
                hql = "(BeginTime>=${0}$ and BeginTime<=${1}$ or EndTime>=${0}$ and EndTime<=${1}$ or BeginTime<=${0}$ and EndTime>=${1}$ or BeginTime<=${1}$ and EndTime is null)and Teacher=${2}$ ";
                paramList.Clear();
                paramList.Add(this.StartTime);
                paramList.Add(dtEnd);
                paramList.Add(this.TeacherKey);
                if (this.DeviceKey > 0)
                {
                    hql += " and Device=${" + paramList.Count + "}$";
                    paramList.Add(this.DeviceKey);
                }

                hql += "order by ";
                if (!string.IsNullOrEmpty(this.OrderField))
                {
                    hql += (this.OrderField + ",");
                }
                hql += "BeginTime asc";

                List<THU.LabSystemBE.DeviceUseRecord> useList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql, paramList);
                foreach (THU.LabSystemBE.DeviceUseRecord useRecord in useList)
                {
                    THU.LabSystemBE.Deploy.DeviceUseReportDTO reportDTO = new LabSystemBE.Deploy.DeviceUseReportDTO();

                    DateTime bt = (useRecord.BeginTime < this.StartTime ? this.StartTime : useRecord.BeginTime);
                    DateTime et = DateTime.Now;
                    if (useRecord.EndTime != null)
                    {
                        if (useRecord.EndTime.Value < dtEnd)
                        {
                            et = useRecord.EndTime.Value;
                        }
                    }
                    if (et > dtEnd)
                    {
                        et = dtEnd;
                    }
                    double hours = (et - bt).TotalHours;
                    if (hours > 0)
                    {
                        reportDTO.Hours = hours;
                        reportDTO.Fee = Convert.ToDecimal(Math.Round(hours, 2)) * useRecord.Price;
                    }

                    reportDTO.Hours = Math.Round(reportDTO.Hours, 2);
                    reportDTO.Fee = Math.Round(reportDTO.Fee, 2);

                    reportDTO.DeviceName = useRecord.Device.Device.Name;
                    reportDTO.SN = useRecord.Device.SN;
                    reportDTO.StartTime = bt;// useRecord.BeginTime;
                    reportDTO.EndTime = et;//useRecord.EndTime.Value;
                    reportDTO.HouseName = useRecord.House.Name;
                    reportDTO.UserName = useRecord.User.Name;
                    reportDTO.Price = useRecord.Price;

                    reportExDTO.ListData.Add(reportDTO);
                }
                reportExDTO.ListCount = reportExDTO.ListData.Count;
            }
            return reportExDTO;
        }
    }
}
