using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy
{
    public partial class DeviceMapDTO
    {
        public string HouseName { get; set; }
        public string DeviceName { get; set; }
        public string DeviceStatusName { get; set; }
        public string UseStatusName { get; set; }
        public string DeviceTypeName { get; set; }
        public bool CanUse { get; set; }
    }
}
