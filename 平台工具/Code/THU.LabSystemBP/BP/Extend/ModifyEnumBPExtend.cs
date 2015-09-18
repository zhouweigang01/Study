using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ModifyEnumBP
    {
        private THU.LabSystemBE.Deploy.CommonEnumDTO DoExtend()
        {
            THU.LabSystemBE.CommonEnum ce = THU.LabSystemBE.CommonEnum.Finder.FindById(this.EnumDTO.ID);
            if (ce == null)
            {
                throw new Exception("枚举信息不存在");
            }
            ce.FromDTO(this.EnumDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            return ce.ToDTO();
        }
    }
}
