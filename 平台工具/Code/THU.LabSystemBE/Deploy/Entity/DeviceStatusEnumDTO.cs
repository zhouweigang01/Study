using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class DeviceStatusEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected DeviceStatusEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.DeviceStatusEnumDTO")
        {
        }
        public DeviceStatusEnumDTO()
            : base("THU.LabSystemBE.Deploy.DeviceStatusEnumDTO")
        {

        }
		public static explicit operator DeviceStatusEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<DeviceStatusEnumDTO>(value);
        }

        public static explicit operator int(DeviceStatusEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static DeviceStatusEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new DeviceStatusEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new DeviceStatusEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 正常
/// </summary>
private static DeviceStatusEnumDTO _Normal;
/// <summary>
/// 正常
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "正常")]
public static DeviceStatusEnumDTO Normal
{
    get
    {
        if (_Normal == null)
        {
            _Normal = new DeviceStatusEnumDTO(1);
        }
        return _Normal;
    }
}

/// <summary>
/// 故障
/// </summary>
private static DeviceStatusEnumDTO _Fault;
/// <summary>
/// 故障
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "故障")]
public static DeviceStatusEnumDTO Fault
{
    get
    {
        if (_Fault == null)
        {
            _Fault = new DeviceStatusEnumDTO(2);
        }
        return _Fault;
    }
}

/// <summary>
/// 维护
/// </summary>
private static DeviceStatusEnumDTO _Maintain;
/// <summary>
/// 维护
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "维护")]
public static DeviceStatusEnumDTO Maintain
{
    get
    {
        if (_Maintain == null)
        {
            _Maintain = new DeviceStatusEnumDTO(3);
        }
        return _Maintain;
    }
}

/// <summary>
/// 报废
/// </summary>
private static DeviceStatusEnumDTO _Discard;
/// <summary>
/// 报废
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "报废")]
public static DeviceStatusEnumDTO Discard
{
    get
    {
        if (_Discard == null)
        {
            _Discard = new DeviceStatusEnumDTO(4);
        }
        return _Discard;
    }
}

}
}
