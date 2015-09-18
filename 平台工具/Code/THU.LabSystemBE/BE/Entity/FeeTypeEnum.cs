using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class FeeTypeEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected FeeTypeEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.FeeTypeEnum))
        {
        }
        public FeeTypeEnum()
            : base(typeof(THU.LabSystemBE.FeeTypeEnum))
        {

        }
		public static explicit operator FeeTypeEnum(int value)
        {
            return  BaseEnum.GetEnum<FeeTypeEnum>(value);
        }

        public static explicit operator int(FeeTypeEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  FeeTypeEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<FeeTypeEnum>(enumId);
			}
			public static  FeeTypeEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<FeeTypeEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 按小时
/// </summary>
private static FeeTypeEnum _Hour;
/// <summary>
/// 按小时
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static FeeTypeEnum Hour
{
    get
    {
        if (_Hour == null)
        {
            _Hour = new FeeTypeEnum(1, "Hour", "按小时");
        }
        return _Hour;
    }
}

/// <summary>
/// 按天
/// </summary>
private static FeeTypeEnum _Day;
/// <summary>
/// 按天
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static FeeTypeEnum Day
{
    get
    {
        if (_Day == null)
        {
            _Day = new FeeTypeEnum(2, "Day", "按天");
        }
        return _Day;
    }
}

/// <summary>
/// 固定值
/// </summary>
private static FeeTypeEnum _Fix;
/// <summary>
/// 固定值
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static FeeTypeEnum Fix
{
    get
    {
        if (_Fix == null)
        {
            _Fix = new FeeTypeEnum(3, "Fix", "固定值");
        }
        return _Fix;
    }
}

}
}
