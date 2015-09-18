using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertEnumBP
    {
        private THU.LabSystemBE.Deploy.CommonEnumDTO DoExtend()
        {
            THU.LabSystemBE.CommonEnum ce = THU.LabSystemBE.CommonEnum.Create();
            ce.FromDTO(this.EnumDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            return ce.ToDTO();
        }
    }
}
