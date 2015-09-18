using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DiscardDeviceBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceMap deviceMap = THU.LabSystemBE.DeviceMap.Finder.FindById(this.ID);
            if (deviceMap == null)
            {
                throw new Exception("当前设备信息不存在:" + this.ID);
            }
            if (deviceMap.UseStatus == THU.LabSystemBE.UseStatusEnum.Use)
            {
                throw new Exception("当前设备：" + deviceMap.SN + "正在使用中，无法申请报废");
            }

            //看看有没有预约记录
            string hql = "BeginTime<=${0}$ and EndTime >= ${0}$ and IsAppoint=1";
            List<object> paramList = new List<object>();
            paramList.Add(DateTime.Now);
            THU.LabSystemBE.DeviceUseRecord dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
            if (dvRecord != null)
            {
                throw new Exception("当前时间设备“" + deviceMap.SN + "”正在被预约使用，无法申请报废");
            }
            deviceMap.DeviceStatus = THU.LabSystemBE.DeviceStatusEnum.Discard;

            THU.LabSystemBE.DeviceLog deviceLog = THU.LabSystemBE.DeviceLog.Create();
            deviceLog.Status = THU.LabSystemBE.DeviceStatusEnum.Discard;
            deviceLog.OperatorKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            deviceLog.Device = deviceMap;



            NHExt.Runtime.Session.Session.Current.Commit();

            return true;
        }
    }
}
