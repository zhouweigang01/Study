using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class TypeEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected TypeEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.TypeEnumDTO")
        {
        }
        public TypeEnumDTO()
            : base("THU.LabSystemBE.Deploy.TypeEnumDTO")
        {

        }
		public static explicit operator TypeEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<TypeEnumDTO>(value);
        }

        public static explicit operator int(TypeEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static TypeEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new TypeEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new TypeEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 学历
/// </summary>
private static TypeEnumDTO _Degree;
/// <summary>
/// 学历
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "学历")]
public static TypeEnumDTO Degree
{
    get
    {
        if (_Degree == null)
        {
            _Degree = new TypeEnumDTO(1);
        }
        return _Degree;
    }
}

/// <summary>
/// 身份
/// </summary>
private static TypeEnumDTO _Status;
/// <summary>
/// 身份
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "身份")]
public static TypeEnumDTO Status
{
    get
    {
        if (_Status == null)
        {
            _Status = new TypeEnumDTO(2);
        }
        return _Status;
    }
}

/// <summary>
/// 职位
/// </summary>
private static TypeEnumDTO _Position;
/// <summary>
/// 职位
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "职位")]
public static TypeEnumDTO Position
{
    get
    {
        if (_Position == null)
        {
            _Position = new TypeEnumDTO(3);
        }
        return _Position;
    }
}

/// <summary>
/// 部门
/// </summary>
private static TypeEnumDTO _Department;
/// <summary>
/// 部门
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "部门")]
public static TypeEnumDTO Department
{
    get
    {
        if (_Department == null)
        {
            _Department = new TypeEnumDTO(4);
        }
        return _Department;
    }
}

/// <summary>
/// 房间
/// </summary>
private static TypeEnumDTO _House;
/// <summary>
/// 房间
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "房间")]
public static TypeEnumDTO House
{
    get
    {
        if (_House == null)
        {
            _House = new TypeEnumDTO(5);
        }
        return _House;
    }
}

}
}
