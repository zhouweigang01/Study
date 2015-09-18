using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy
{
    public partial class DeviceUseRecordDTO
    {
        public double TotalHours { get; set; }
        public string DeviceStatusName { get; set; }
        public string UseStatusName { get; set; }
        public string DeviceUseStatusName { get; set; }
        public string UserName { get; set; }
        public string UserTel { get; set; }
        public string DeviceSN { get; set; }
        public string DeviceName { get; set; }
        public string HouseName { get; set; }
        /// <summary>
        /// 图表显示使用
        /// </summary>
        public string BeginDateStr { get; set; }
        /// <summary>
        /// 图表显示使用
        /// </summary>
        public string EndDateStr { get; set; }

        public bool CanAppoint { get; set; }


    }
}
