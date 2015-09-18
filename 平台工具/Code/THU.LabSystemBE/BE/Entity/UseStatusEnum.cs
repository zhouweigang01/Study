using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class UseStatusEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected UseStatusEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.UseStatusEnum))
        {
        }
        public UseStatusEnum()
            : base(typeof(THU.LabSystemBE.UseStatusEnum))
        {

        }
		public static explicit operator UseStatusEnum(int value)
        {
            return  BaseEnum.GetEnum<UseStatusEnum>(value);
        }

        public static explicit operator int(UseStatusEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  UseStatusEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<UseStatusEnum>(enumId);
			}
			public static  UseStatusEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<UseStatusEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 使用中
/// </summary>
private static UseStatusEnum _Use;
/// <summary>
/// 使用中
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static UseStatusEnum Use
{
    get
    {
        if (_Use == null)
        {
            _Use = new UseStatusEnum(1, "Use", "使用中");
        }
        return _Use;
    }
}

/// <summary>
/// 未使用
/// </summary>
private static UseStatusEnum _Idle;
/// <summary>
/// 未使用
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static UseStatusEnum Idle
{
    get
    {
        if (_Idle == null)
        {
            _Idle = new UseStatusEnum(2, "Idle", "未使用");
        }
        return _Idle;
    }
}

}
}
