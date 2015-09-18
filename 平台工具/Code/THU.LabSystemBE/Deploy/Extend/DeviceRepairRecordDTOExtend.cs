using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy
{
    public partial class DeviceRepairRecordDTO
    {
        public string DeviceStatusName { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        public string DeviceSN { get; set; }
        public string DeviceName { get; set; }
        public string HouseName { get; set; }
    }
}
