using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ApplyRepairBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceMap deviceMap = null;
            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.FindById(this.ID);
            if (useRecord == null)
            {
                deviceMap = THU.LabSystemBE.DeviceMap.Finder.FindById(this.ID);
            }
            else
            {
                useRecord.IsCompleted = true;
                //ԤԼ�豸Ҳ���Ա���
                //if (!useRecord.IsAppoint)
                //{
                useRecord.EndTime = DateTime.Now;
                // }
                NHExt.Runtime.Session.Session.Current.Commit();
                deviceMap = useRecord.Device;
            }
            if (deviceMap == null)
            {
                throw new Exception("�����豸��Ϣ������");
            }
            if (deviceMap.DeviceStatus == THU.LabSystemBE.DeviceStatusEnum.Discard)
            {
                throw new Exception("��ǰ�豸�Ѿ����ϣ�����ʧ��");
            }
            //�豸���ޣ�����һ�����޼�¼
            THU.LabSystemBE.DeviceRepairRecord repaireRecord = THU.LabSystemBE.DeviceRepairRecord.Create();
            repaireRecord.UserKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            repaireRecord.ReportMemo = this.Memo;
            repaireRecord.Device = deviceMap;
            //����
            repaireRecord.Device.DeviceStatus = THU.LabSystemBE.DeviceStatusEnum.Fault;
            NHExt.Runtime.Session.Session.Current.Commit();

            return true;

        }
    }
}
