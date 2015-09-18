using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ModifyRepairAlarmBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceRepairRecord repairRecord = THU.LabSystemBE.DeviceRepairRecord.Finder.FindById(this.ID);
            if (repairRecord == null)
            {
                throw new Exception("Î¬ÐÞ¼ÇÂ¼²»´æÔÚ");
            }
            repairRecord.AlarmUser = false;
            return true;
        }
    }
}
