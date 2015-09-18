using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Enums;
using NHExt.Runtime.Model;

namespace THU.LabSystemBE
{
	[Serializable]
    public partial class BizEnum : NHExt.Runtime.Model.BaseEnum
    {
        protected BizEnum(int v, string code, string name)
            : base(v, code, name, typeof(THU.LabSystemBE.BizEnum))
        {
        }
        public BizEnum()
            : base(typeof(THU.LabSystemBE.BizEnum))
        {

        }
		public static explicit operator BizEnum(int value)
        {
            return  BaseEnum.GetEnum<BizEnum>(value);
        }

        public static explicit operator int(BizEnum obj)
        {
            return obj.EnumValue;
        }

		#region 实体查询相关函数
		public static class Finder{
			public static  BizEnum FindByID(int enumId){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<BizEnum>(enumId);
			}
			public static  BizEnum FindByCode(string enumCode){
				return   NHExt.Runtime.Model.BaseEnum.GetEnum<BizEnum>(enumCode);
			}
		}
		#endregion 
}
}
