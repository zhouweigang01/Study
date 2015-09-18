using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class HandleRepairBP
    {
        private bool DoExtend()
        {
            //�ҵ����޼�¼���д���
            THU.LabSystemBE.DeviceRepairRecord repairRecord = THU.LabSystemBE.DeviceRepairRecord.Finder.FindById(this.ID);
            if (repairRecord == null)
            {
                throw new Exception("���޼�¼�����ڣ��������������");
            }
            if (repairRecord.CompleteDate != null)
            {
                throw new Exception("��ǰ�豸�Ѿ�ά�����,����ʧ��");
            }
            repairRecord.RepairDate = DateTime.Now;
            repairRecord.CompleteUserKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (repairRecord.Device.DeviceStatus != THU.LabSystemBE.DeviceStatusEnum.Discard)
            {
                repairRecord.Device.DeviceStatus = THU.LabSystemBE.DeviceStatusEnum.Maintain;
            }

            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
