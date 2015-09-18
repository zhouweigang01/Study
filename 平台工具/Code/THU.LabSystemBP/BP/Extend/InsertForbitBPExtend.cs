using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertForbitBP
    {
        private THU.LabSystemBE.Deploy.ForbidUserDTO DoExtend()
        {
            THU.LabSystemBE.ForbidUser forbit = THU.LabSystemBE.ForbidUser.Create();
            forbit.UserKey = new NHExt.Runtime.Model.EntityKey<LabSystemBE.User>(this.ForbitDTO.User);
            forbit.StartTime = this.ForbitDTO.StartTime;
            forbit.EndTime = this.ForbitDTO.EndTime;
            NHExt.Runtime.Session.Session.Current.Commit();
            return forbit.ToDTO();
        }
    }
}
