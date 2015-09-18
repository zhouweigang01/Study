using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteForbitBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.ForbidUser forbit = THU.LabSystemBE.ForbidUser.Finder.FindById(this.ID);
            if (forbit != null)
            {
                NHExt.Runtime.Session.Session.Current.Remove(forbit);
                NHExt.Runtime.Session.Session.Current.Commit();
            }
            return true;
        }
    }
}
