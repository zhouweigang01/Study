using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ModifyDeviceMapBP
    {
        private THU.LabSystemBE.Deploy.DeviceMapDTO DoExtend()
        {
            THU.LabSystemBE.DeviceMap deviceMap = THU.LabSystemBE.DeviceMap.Finder.FindById(this.DeviceMapDTO.ID);
            deviceMap.FromDTO(this.DeviceMapDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            return deviceMap.ToDTO();
        }
    }
}
