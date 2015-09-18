using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceRepairRecordBP
    {
        private THU.LabSystemBE.Deploy.DeviceRepairExDTO DoExtend()
        {
            string hql = "1=1";
            List<object> paramList = new List<object>();
            if (this.IsCompleted != null)
            {
                hql += " and IsCompleted=${" + paramList.Count + "}$";
                paramList.Add(this.IsCompleted);
            }
            if (this.UserKey > 0)
            {
                hql += " and User=${" + paramList.Count + "}$ and (AlarmUser=1 or AlarmUser is null)";
                paramList.Add(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            }
            if (this.DeviceKey > 0)
            {
                hql += " and Device=${" + paramList.Count + "}$";
                paramList.Add(this.DeviceKey);
            }
            string hqlOrder = " order by ID desc";
            List<THU.LabSystemBE.DeviceRepairRecord> repairList = null;
            if (this.PageSize > 0 && this.PageIndex > 0)
            {
                repairList = THU.LabSystemBE.DeviceRepairRecord.Finder.FindAll(hql + hqlOrder, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
            }
            else
            {
                repairList = THU.LabSystemBE.DeviceRepairRecord.Finder.FindAll(hql + hqlOrder, paramList);
            }
            THU.LabSystemBE.Deploy.DeviceRepairExDTO repairExDTO = new LabSystemBE.Deploy.DeviceRepairExDTO();
            repairExDTO.ListData = new List<LabSystemBE.Deploy.DeviceRepairRecordDTO>();
            foreach (THU.LabSystemBE.DeviceRepairRecord repair in repairList)
            {
                repairExDTO.ListData.Add(repair.ToDTO());
            }
            repairExDTO.ListCount = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.DeviceRepairRecord>(hql, paramList) ?? 0;
            return repairExDTO;
        }
    }
}
