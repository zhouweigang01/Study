using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class UseStatusEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected UseStatusEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.UseStatusEnumDTO")
        {
        }
        public UseStatusEnumDTO()
            : base("THU.LabSystemBE.Deploy.UseStatusEnumDTO")
        {

        }
		public static explicit operator UseStatusEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<UseStatusEnumDTO>(value);
        }

        public static explicit operator int(UseStatusEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static UseStatusEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new UseStatusEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new UseStatusEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 使用中
/// </summary>
private static UseStatusEnumDTO _Use;
/// <summary>
/// 使用中
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "使用中")]
public static UseStatusEnumDTO Use
{
    get
    {
        if (_Use == null)
        {
            _Use = new UseStatusEnumDTO(1);
        }
        return _Use;
    }
}

/// <summary>
/// 未使用
/// </summary>
private static UseStatusEnumDTO _Idle;
/// <summary>
/// 未使用
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "未使用")]
public static UseStatusEnumDTO Idle
{
    get
    {
        if (_Idle == null)
        {
            _Idle = new UseStatusEnumDTO(2);
        }
        return _Idle;
    }
}

}
}
