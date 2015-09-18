using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class UseCompleteBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.FindById(this.ID);
            if (useRecord == null)
            {
                throw new Exception("����ʧ�ܣ�������ʹ�ü�¼ID:" + this.ID);
            }
            if (!useRecord.IsAppoint)
            {
                useRecord.EndTime = DateTime.Now;
            }
            useRecord.IsCompleted = true;
            NHExt.Runtime.Session.Session.Current.Commit();
            return true;

        }
    }
}
