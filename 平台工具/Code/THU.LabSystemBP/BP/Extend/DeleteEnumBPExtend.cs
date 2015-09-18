using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteEnumBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.CommonEnum ce = THU.LabSystemBE.CommonEnum.Finder.FindById(this.ID);
            if (ce == null)
            {
                throw new Exception("枚举信息不存在,ID:" + this.ID);
            }
            try
            {
                NHExt.Runtime.Session.Session.Current.Remove(ce);
                NHExt.Runtime.Session.Session.Current.Commit();
            }
            catch (Exception ex)
            {
                ce.EntityState = NHExt.Runtime.Enums.EntityState.Update;
                ce.IsDelete = true;
                NHExt.Runtime.Session.Session.Current.InList(ce);
            }
            return true;
        }
    }
}
