using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class SynDeviceMapBP
    {
        private bool DoExtend()
        {
            //更新所有设备的状态

            string hql = string.Empty;
            List<object> paramList = new List<object>();
            List<THU.LabSystemBE.DeviceMap> deviceMapList = THU.LabSystemBE.DeviceMap.Finder.FindAll("1=1");
            foreach (THU.LabSystemBE.DeviceMap deviceMap in deviceMapList)
            {
                paramList.Clear();
                paramList.Add(deviceMap.ID);
                paramList.Add(DateTime.Now);
                hql = "Device=${0}$ and EndTime<=${1}$ and IsAppoint=1 and IsCompleted=0";
                List<THU.LabSystemBE.DeviceUseRecord> useRecords = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql, paramList);
                foreach (THU.LabSystemBE.DeviceUseRecord useRecord in useRecords)
                {
                    useRecord.IsCompleted = true;
                }
            }
            NHExt.Runtime.Session.Session.Current.Commit();
            foreach (THU.LabSystemBE.DeviceMap deviceMap in deviceMapList)
            {
                paramList.Clear();
                paramList.Add(deviceMap.ID);
                paramList.Add(DateTime.Now);
                hql = "Device=${0}$ and ((BeginTime<=${1}$ and IsCompleted=0 and IsAppoint=0) or(BeginTime<=${1}$ and EndTime>=${1}$ and IsCompleted=0 and IsAppoint=1))";
                List<THU.LabSystemBE.DeviceUseRecord> useRecords = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql, paramList);
                if (deviceMap.DeviceStatus == THU.LabSystemBE.DeviceStatusEnum.Normal)
                {
                    if (useRecords.Count > 0)
                    {
                        deviceMap.UseStatus = THU.LabSystemBE.UseStatusEnum.Use;
                    }
                    else
                    {
                        deviceMap.UseStatus = THU.LabSystemBE.UseStatusEnum.Idle;
                    }

                }
                //更新所有预约设备记录
                foreach (THU.LabSystemBE.DeviceUseRecord useRecord in useRecords)
                {
                    useRecord.IsUsing = true;
                }
            }



            return true;
        }
    }
}
