using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class DeviceRepairRecord
    {

        private void FromDTOImpl(Deploy.DeviceRepairRecordDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.DeviceRepairRecordDTO dto)
        {
            dto.DeviceStatusName = this.Device.DeviceStatus.Name;
            dto.UserName = this.User.Name;
            dto.UserTel = this.User.Tel;
            dto.DeviceSN = this.Device.SN;
            dto.DeviceName = this.Device.Device.Name;
            dto.HouseName = this.Device.House.Name;
        }
        private void OnSetDefaultValue()
        {

        }
        private void OnValidate()
        {
            if (this.Device == null)
            {
                throw new Exception("维修设备不能为空");
            }
            if (this.User == null)
            {
                throw new Exception("报修人不能为空");
            }
        }
        private void OnInserting()
        {
            this.ReportDate = DateTime.Now;
            this.Teacher = this.User.Teacher;
            this.House = this.Device.House;
            this.AlarmUser = true;
        }
        private void OnInserted()
        {

        }
        private void OnUpdating()
        {

        }
        private void OnUpdated()
        {

        }
        private void OnDeleting()
        {

        }
        private void OnDeleted()
        {

        }
    }
}

