using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class DeviceTypeEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected DeviceTypeEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.DeviceTypeEnumDTO")
        {
        }
        public DeviceTypeEnumDTO()
            : base("THU.LabSystemBE.Deploy.DeviceTypeEnumDTO")
        {

        }
		public static explicit operator DeviceTypeEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<DeviceTypeEnumDTO>(value);
        }

        public static explicit operator int(DeviceTypeEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static DeviceTypeEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new DeviceTypeEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new DeviceTypeEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 单用户
/// </summary>
private static DeviceTypeEnumDTO _Single;
/// <summary>
/// 单用户
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "单用户")]
public static DeviceTypeEnumDTO Single
{
    get
    {
        if (_Single == null)
        {
            _Single = new DeviceTypeEnumDTO(1);
        }
        return _Single;
    }
}

/// <summary>
/// 多用户
/// </summary>
private static DeviceTypeEnumDTO _Multiple;
/// <summary>
/// 多用户
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "多用户")]
public static DeviceTypeEnumDTO Multiple
{
    get
    {
        if (_Multiple == null)
        {
            _Multiple = new DeviceTypeEnumDTO(2);
        }
        return _Multiple;
    }
}

}
}
