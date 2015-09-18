using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class RepairCompleteBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceRepairRecord repairRecord = THU.LabSystemBE.DeviceRepairRecord.Finder.FindById(this.ID);
            if (repairRecord == null)
            {
                throw new Exception("���޼�¼�����ڣ��������������");
            }
            if (repairRecord.RepairDate == null)
            {
                throw new Exception("��ǰ�豸��û�п�ʼά�ޣ�ά����ɲ���ʧ��");
            }
            repairRecord.Fee = this.Fee;
            if (repairRecord.CompleteDate == null)
            {
                repairRecord.CompleteDate = DateTime.Now;
            }
            repairRecord.IsCompleted = true;
            repairRecord.RepairMemo = this.Memo;
            if (repairRecord.Device.DeviceStatus != THU.LabSystemBE.DeviceStatusEnum.Discard)
            {
                repairRecord.Device.DeviceStatus = THU.LabSystemBE.DeviceStatusEnum.Normal;
            }

            NHExt.Runtime.Session.Session.Current.Commit();

            return true;
        }
    }
}
