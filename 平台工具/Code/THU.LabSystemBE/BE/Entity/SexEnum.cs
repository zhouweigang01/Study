using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class SexEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected SexEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.SexEnum))
        {
        }
        public SexEnum()
            : base(typeof(THU.LabSystemBE.SexEnum))
        {

        }
		public static explicit operator SexEnum(int value)
        {
            return  BaseEnum.GetEnum<SexEnum>(value);
        }

        public static explicit operator int(SexEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  SexEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<SexEnum>(enumId);
			}
			public static  SexEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<SexEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 男
/// </summary>
private static SexEnum _Male;
/// <summary>
/// 男
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static SexEnum Male
{
    get
    {
        if (_Male == null)
        {
            _Male = new SexEnum(1, "Male", "男");
        }
        return _Male;
    }
}

/// <summary>
/// 女
/// </summary>
private static SexEnum _Female;
/// <summary>
/// 女
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static SexEnum Female
{
    get
    {
        if (_Female == null)
        {
            _Female = new SexEnum(2, "Female", "女");
        }
        return _Female;
    }
}

}
}
