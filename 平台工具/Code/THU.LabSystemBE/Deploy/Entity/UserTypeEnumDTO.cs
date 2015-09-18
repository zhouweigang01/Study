using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class UserTypeEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected UserTypeEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.UserTypeEnumDTO")
        {
        }
        public UserTypeEnumDTO()
            : base("THU.LabSystemBE.Deploy.UserTypeEnumDTO")
        {

        }
		public static explicit operator UserTypeEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<UserTypeEnumDTO>(value);
        }

        public static explicit operator int(UserTypeEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static UserTypeEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new UserTypeEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new UserTypeEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 使用者
/// </summary>
private static UserTypeEnumDTO _User;
/// <summary>
/// 使用者
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "使用者")]
public static UserTypeEnumDTO User
{
    get
    {
        if (_User == null)
        {
            _User = new UserTypeEnumDTO(1);
        }
        return _User;
    }
}

/// <summary>
/// 管理员
/// </summary>
private static UserTypeEnumDTO _Admin;
/// <summary>
/// 管理员
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "管理员")]
public static UserTypeEnumDTO Admin
{
    get
    {
        if (_Admin == null)
        {
            _Admin = new UserTypeEnumDTO(2);
        }
        return _Admin;
    }
}

/// <summary>
/// 超级管理员
/// </summary>
private static UserTypeEnumDTO _Super;
/// <summary>
/// 超级管理员
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "超级管理员")]
public static UserTypeEnumDTO Super
{
    get
    {
        if (_Super == null)
        {
            _Super = new UserTypeEnumDTO(3);
        }
        return _Super;
    }
}

}
}
