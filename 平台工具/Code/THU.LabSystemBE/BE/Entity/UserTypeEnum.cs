using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class UserTypeEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected UserTypeEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.UserTypeEnum))
        {
        }
        public UserTypeEnum()
            : base(typeof(THU.LabSystemBE.UserTypeEnum))
        {

        }
		public static explicit operator UserTypeEnum(int value)
        {
            return  BaseEnum.GetEnum<UserTypeEnum>(value);
        }

        public static explicit operator int(UserTypeEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  UserTypeEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<UserTypeEnum>(enumId);
			}
			public static  UserTypeEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<UserTypeEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 使用者
/// </summary>
private static UserTypeEnum _User;
/// <summary>
/// 使用者
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static UserTypeEnum User
{
    get
    {
        if (_User == null)
        {
            _User = new UserTypeEnum(1, "User", "使用者");
        }
        return _User;
    }
}

/// <summary>
/// 管理员
/// </summary>
private static UserTypeEnum _Admin;
/// <summary>
/// 管理员
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static UserTypeEnum Admin
{
    get
    {
        if (_Admin == null)
        {
            _Admin = new UserTypeEnum(2, "Admin", "管理员");
        }
        return _Admin;
    }
}

/// <summary>
/// 超级管理员
/// </summary>
private static UserTypeEnum _Super;
/// <summary>
/// 超级管理员
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static UserTypeEnum Super
{
    get
    {
        if (_Super == null)
        {
            _Super = new UserTypeEnum(3, "Super", "超级管理员");
        }
        return _Super;
    }
}

}
}
