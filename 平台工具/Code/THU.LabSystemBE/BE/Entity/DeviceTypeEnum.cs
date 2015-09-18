using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class DeviceTypeEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected DeviceTypeEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.DeviceTypeEnum))
        {
        }
        public DeviceTypeEnum()
            : base(typeof(THU.LabSystemBE.DeviceTypeEnum))
        {

        }
		public static explicit operator DeviceTypeEnum(int value)
        {
            return  BaseEnum.GetEnum<DeviceTypeEnum>(value);
        }

        public static explicit operator int(DeviceTypeEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  DeviceTypeEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<DeviceTypeEnum>(enumId);
			}
			public static  DeviceTypeEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<DeviceTypeEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 单用户
/// </summary>
private static DeviceTypeEnum _Single;
/// <summary>
/// 单用户
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static DeviceTypeEnum Single
{
    get
    {
        if (_Single == null)
        {
            _Single = new DeviceTypeEnum(1, "Single", "单用户");
        }
        return _Single;
    }
}

/// <summary>
/// 多用户
/// </summary>
private static DeviceTypeEnum _Multiple;
/// <summary>
/// 多用户
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static DeviceTypeEnum Multiple
{
    get
    {
        if (_Multiple == null)
        {
            _Multiple = new DeviceTypeEnum(2, "Multiple", "多用户");
        }
        return _Multiple;
    }
}

}
}
