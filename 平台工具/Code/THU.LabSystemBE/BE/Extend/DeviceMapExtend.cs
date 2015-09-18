using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class DeviceMap
    {

        private void FromDTOImpl(Deploy.DeviceMapDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.DeviceMapDTO dto)
        {
            dto.HouseName = this.House.Name;
            dto.DeviceName = this.Device.Name;
            dto.DeviceStatusName = this.DeviceStatus.Name;
            dto.UseStatusName = this.UseStatus.Name;
            dto.DeviceTypeName = this.Device.Type.Name;
            dto.CanUse = false;
            if (this.DeviceStatus == THU.LabSystemBE.DeviceStatusEnum.Normal)
            {
                if (this.UseStatus == THU.LabSystemBE.UseStatusEnum.Idle)
                {
                    dto.CanUse = true;
                }
                else if (this.Device.Type == THU.LabSystemBE.DeviceTypeEnum.Multiple)
                {
                    dto.CanUse = true;
                }
            }

        }
        private void OnSetDefaultValue()
        {

        }
        private void OnValidate()
        {
            string hql = "SN=${0}$ and IsDelete=0 and ID!=${1}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.SN);
            paramList.Add(this.ID);
            DeviceMap dm = DeviceMap.Finder.Find(hql, paramList);
            if (dm != null)
            {
                throw new Exception("当前设备号“" + this.SN + "”的设备已经存在");
            }
        }
        private void OnInserting()
        {
            this.UseStatus = UseStatusEnum.Idle;
            this.DeviceStatus = DeviceStatusEnum.Normal;
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

