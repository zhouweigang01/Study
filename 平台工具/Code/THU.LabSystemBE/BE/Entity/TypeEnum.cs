using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class TypeEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected TypeEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.TypeEnum))
        {
        }
        public TypeEnum()
            : base(typeof(THU.LabSystemBE.TypeEnum))
        {

        }
		public static explicit operator TypeEnum(int value)
        {
            return  BaseEnum.GetEnum<TypeEnum>(value);
        }

        public static explicit operator int(TypeEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  TypeEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<TypeEnum>(enumId);
			}
			public static  TypeEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<TypeEnum>(enumCode);
			}
		}
		#endregion 
/// <summary>
/// 学历
/// </summary>
private static TypeEnum _Degree;
/// <summary>
/// 学历
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static TypeEnum Degree
{
    get
    {
        if (_Degree == null)
        {
            _Degree = new TypeEnum(1, "Degree", "学历");
        }
        return _Degree;
    }
}

/// <summary>
/// 身份
/// </summary>
private static TypeEnum _Status;
/// <summary>
/// 身份
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static TypeEnum Status
{
    get
    {
        if (_Status == null)
        {
            _Status = new TypeEnum(2, "Status", "身份");
        }
        return _Status;
    }
}

/// <summary>
/// 职位
/// </summary>
private static TypeEnum _Position;
/// <summary>
/// 职位
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static TypeEnum Position
{
    get
    {
        if (_Position == null)
        {
            _Position = new TypeEnum(3, "Position", "职位");
        }
        return _Position;
    }
}

/// <summary>
/// 部门
/// </summary>
private static TypeEnum _Department;
/// <summary>
/// 部门
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static TypeEnum Department
{
    get
    {
        if (_Department == null)
        {
            _Department = new TypeEnum(4, "Department", "部门");
        }
        return _Department;
    }
}

/// <summary>
/// 房间
/// </summary>
private static TypeEnum _House;
/// <summary>
/// 房间
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
public static TypeEnum House
{
    get
    {
        if (_House == null)
        {
            _House = new TypeEnum(5, "House", "房间");
        }
        return _House;
    }
}

}
}
