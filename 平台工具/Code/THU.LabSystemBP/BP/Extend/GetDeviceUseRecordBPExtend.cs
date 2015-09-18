using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceUseRecordBP
    {
        private THU.LabSystemBE.Deploy.DeviceUseExDTO DoExtend()
        {
            string hql = "1=1 ";
            string hqlOrder = string.Empty;
            List<object> paramList = new List<object>();

            if (this.UserKey > 0)
            {
                hql += " and User=${" + paramList.Count + "}$ ";
                paramList.Add(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            }

            if (this.IsAppoint)
            {
                hql += " and (IsCompleted=0 and IsAppoint=1) ";//and EndTime >=${" + paramList.Count + "}$";
                // paramList.Add(DateTime.Now);
            }
            else
            {

                if (this.UserKey > 0)
                {
                    // hql += " and (IsUsing=1 or IsCompleted=1 or IsAppoint=1 and (BeginTime>=${" + btIndex + "}$ and BeginTime<=${" + etIndex + "}$ or EndTime>=${" + btIndex + "}$ and EndTime<=${" + etIndex + "}$ or BeginTime<=${" + btIndex + "}$ and EndTime>=${" + etIndex + "}$))";
                    hql += " and (IsUsing=1 or IsCompleted=1)";

                }
                else
                {
                    DateTime bt = DateTime.Now.Date;
                    DateTime et = bt.AddDays(1).AddSeconds(-1);
                    int btIndex = paramList.Count;
                    int etIndex = btIndex + 1;
                    hql += " and (IsUsing=1 or IsCompleted=1 and (BeginTime>=${" + btIndex + "}$ and BeginTime<=${" + etIndex + "}$ or EndTime>=${" + btIndex + "}$ and EndTime<=${" + etIndex + "}$ or BeginTime<=${" + btIndex + "}$ and EndTime>=${" + etIndex + "}$))";
                    paramList.Add(bt);
                    paramList.Add(et);
                }

            }

            hqlOrder = " order by BeginTime desc";



            List<THU.LabSystemBE.DeviceUseRecord> deviceUseList;
            if (this.PageSize > 0 && this.PageIndex > 0)
            {
                deviceUseList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql + hqlOrder, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
            }
            else
            {
                deviceUseList = THU.LabSystemBE.DeviceUseRecord.Finder.FindAll(hql + hqlOrder, paramList);
            }

            THU.LabSystemBE.Deploy.DeviceUseExDTO useRecordExDTO = new LabSystemBE.Deploy.DeviceUseExDTO();
            useRecordExDTO.ListData = new List<LabSystemBE.Deploy.DeviceUseRecordDTO>();

            foreach (THU.LabSystemBE.DeviceUseRecord deviceUse in deviceUseList)
            {
                THU.LabSystemBE.Deploy.DeviceUseRecordDTO deviceUseDTO = deviceUse.ToDTO();
                //if (deviceUse.IsAppoint && !deviceUse.IsCompleted)
                //{
                //    deviceUseDTO.DeviceStatusName = "‘§‘º π”√";
                //}
                useRecordExDTO.ListData.Add(deviceUseDTO);
            }
            useRecordExDTO.ListCount = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.DeviceUseRecord>(hql, paramList) ?? 0;
            return useRecordExDTO;
        }
    }
}
