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
                throw new Exception("报修记录不存在，处理报修请求错误");
            }
            if (repairRecord.RepairDate == null)
            {
                throw new Exception("当前设备还没有开始维修，维修完成操作失败");
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
