using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class SexEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected SexEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.SexEnumDTO")
        {
        }
        public SexEnumDTO()
            : base("THU.LabSystemBE.Deploy.SexEnumDTO")
        {

        }
		public static explicit operator SexEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<SexEnumDTO>(value);
        }

        public static explicit operator int(SexEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static SexEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new SexEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new SexEnumDTO();
                }
                return _empty;
            }
        }
/// <summary>
/// 男
/// </summary>
private static SexEnumDTO _Male;
/// <summary>
/// 男
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "男")]
public static SexEnumDTO Male
{
    get
    {
        if (_Male == null)
        {
            _Male = new SexEnumDTO(1);
        }
        return _Male;
    }
}

/// <summary>
/// 女
/// </summary>
private static SexEnumDTO _Female;
/// <summary>
/// 女
/// </summary>
[NHExt.Runtime.EntityAttribute.EnumProperty]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Description = "女")]
public static SexEnumDTO Female
{
    get
    {
        if (_Female == null)
        {
            _Female = new SexEnumDTO(2);
        }
        return _Female;
    }
}

}
}
