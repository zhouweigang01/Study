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
                throw new Exception("��ǰ�豸��Ϣ������:" + this.ID);
            }
            if (deviceMap.UseStatus == THU.LabSystemBE.UseStatusEnum.Use)
            {
                throw new Exception("��ǰ�豸��" + deviceMap.SN + "����ʹ���У��޷����뱨��");
            }

            //������û��ԤԼ��¼
            string hql = "BeginTime<=${0}$ and EndTime >= ${0}$ and IsAppoint=1";
            List<object> paramList = new List<object>();
            paramList.Add(DateTime.Now);
            THU.LabSystemBE.DeviceUseRecord dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
            if (dvRecord != null)
            {
                throw new Exception("��ǰʱ���豸��" + deviceMap.SN + "�����ڱ�ԤԼʹ�ã��޷����뱨��");
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
