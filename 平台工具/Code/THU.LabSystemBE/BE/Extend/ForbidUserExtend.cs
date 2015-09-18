using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class ForbidUser
    {

        private void FromDTOImpl(Deploy.ForbidUserDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.ForbidUserDTO dto)
        {
            dto.UserName = this.User.Name;

        }
        private void OnSetDefaultValue()
        {

        }
        private void OnValidate()
        {
            User usr = User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (usr == null || usr.Type != UserTypeEnum.Admin)
            {
                throw new Exception("用户没有修改的权限");
            }
            if (this.EndTime < this.StartTime)
            {
                throw new Exception("惩罚记录结束时间必须大于开始时间");
            }
        }
        private void OnInserting()
        {

        }
        private void OnInserted()
        {

        }
        private void OnUpdating()
        {

        }
        private void OnUpdated()
        {

        }
        private void OnDeleting()
        {

        }
        private void OnDeleted()
        {

        }
    }
}

