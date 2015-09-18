using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE.Deploy
{
    public partial class BizEnumDTO : NHExt.Runtime.Model.BaseEnumDTO
    {
        protected BizEnumDTO(int v)
            : base(v, "THU.LabSystemBE.Deploy.BizEnumDTO")
        {
        }
        public BizEnumDTO()
            : base("THU.LabSystemBE.Deploy.BizEnumDTO")
        {

        }
		public static explicit operator BizEnumDTO(int value)
        {
            return  BaseEnumDTO.GetEnum<BizEnumDTO>(value);
        }

        public static explicit operator int(BizEnumDTO obj)
        {
            return obj.EnumValue;
        }
        private static BizEnumDTO _empty;
		[NHExt.Runtime.EntityAttribute.EnumProperty]
        public static new BizEnumDTO Empty
        {
            get
            {
                if (_empty == null)
                {
                    _empty = new BizEnumDTO();
                }
                return _empty;
            }
        }
}
}
