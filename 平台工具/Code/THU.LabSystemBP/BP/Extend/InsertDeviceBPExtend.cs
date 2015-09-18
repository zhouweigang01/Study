using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertDeviceBP
    {
        private THU.LabSystemBE.Deploy.DeviceDTO DoExtend()
        {
            THU.LabSystemBE.Device device = THU.LabSystemBE.Device.Create();
            device.FromDTO(this.DeviceDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            return device.ToDTO();
        }
    }
}
