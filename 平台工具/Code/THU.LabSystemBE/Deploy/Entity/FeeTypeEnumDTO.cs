using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class FeeTypeEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected FeeTypeEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.FeeTypeEnumDTO")
        {
        }
        public FeeTypeEnumDTO()
            : base("THU.LabSystemBE.Deploy.FeeTypeEnumDTO")
        {

        }
		public static explicit operator FeeTypeEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<FeeTypeEnumDTO>(value);
        }

        public static explicit operator int(FeeTypeEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static FeeTypeEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new FeeTypeEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new FeeTypeEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 按小时
/// </summary>
private static FeeTypeEnumDTO _Hour;
/// <summary>
/// 按小时
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "按小时")]
public static FeeTypeEnumDTO Hour
{
    get
    {
        if (_Hour == null)
        {
            _Hour = new FeeTypeEnumDTO(1);
        }
        return _Hour;
    }
}

/// <summary>
/// 按天
/// </summary>
private static FeeTypeEnumDTO _Day;
/// <summary>
/// 按天
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "按天")]
public static FeeTypeEnumDTO Day
{
    get
    {
        if (_Day == null)
        {
            _Day = new FeeTypeEnumDTO(2);
        }
        return _Day;
    }
}

/// <summary>
/// 固定值
/// </summary>
private static FeeTypeEnumDTO _Fix;
/// <summary>
/// 固定值
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "固定值")]
public static FeeTypeEnumDTO Fix
{
    get
    {
        if (_Fix == null)
        {
            _Fix = new FeeTypeEnumDTO(3);
        }
        return _Fix;
    }
}

}
}
