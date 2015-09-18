using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ModifyForbitBP
    {
        private THU.LabSystemBE.Deploy.ForbidUserDTO DoExtend()
        {
            THU.LabSystemBE.ForbidUser forbit = THU.LabSystemBE.ForbidUser.Finder.FindById(this.ForbitDTO.ID);
            if (forbit == null)
            {
                throw new Exception("当前记录不存在，请刷新重试");
            }
            forbit.StartTime = this.ForbitDTO.StartTime;
            forbit.EndTime = this.ForbitDTO.EndTime;
            NHExt.Runtime.Session.Session.Current.Commit();
            return forbit.ToDTO();
        }
    }
}
