using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class DeviceStatusEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected DeviceStatusEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.DeviceStatusEnum))
        {
        }
        public DeviceStatusEnum()
            : base(typeof(THU.LabSystemBE.DeviceStatusEnum))
        {

        }
		public static explicit operator DeviceStatusEnum(int value)
        {
            return  BaseEnum.GetEnum<DeviceStatusEnum>(value);
        }

        public static explicit operator int(DeviceStatusEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  DeviceStatusEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<DeviceStatusEnum>(enumId);
			}
			public static  DeviceStatusEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<DeviceStatusEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 正常
/// </summary>
private static DeviceStatusEnum _Normal;
/// <summary>
/// 正常
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static DeviceStatusEnum Normal
{
    get
    {
        if (_Normal == null)
        {
            _Normal = new DeviceStatusEnum(1, "Normal", "正常");
        }
        return _Normal;
    }
}

/// <summary>
/// 故障
/// </summary>
private static DeviceStatusEnum _Fault;
/// <summary>
/// 故障
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static DeviceStatusEnum Fault
{
    get
    {
        if (_Fault == null)
        {
            _Fault = new DeviceStatusEnum(2, "Fault", "故障");
        }
        return _Fault;
    }
}

/// <summary>
/// 维护
/// </summary>
private static DeviceStatusEnum _Maintain;
/// <summary>
/// 维护
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static DeviceStatusEnum Maintain
{
    get
    {
        if (_Maintain == null)
        {
            _Maintain = new DeviceStatusEnum(3, "Maintain", "维护");
        }
        return _Maintain;
    }
}

/// <summary>
/// 报废
/// </summary>
private static DeviceStatusEnum _Discard;
/// <summary>
/// 报废
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static DeviceStatusEnum Discard
{
    get
    {
        if (_Discard == null)
        {
            _Discard = new DeviceStatusEnum(4, "Discard", "报废");
        }
        return _Discard;
    }
}

}
}
