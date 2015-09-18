using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ChangePasswordBP
    {
        private bool DoExtend()
        {
            if (this.OPassword == this.Password)
            {
                throw new Exception("原密码和新密码不能相同");
            }
            string encryptPassword = NHExt.Runtime.Util.EncryptHelper.Encrypt(this.OPassword);

            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (usr == null)
            {
                throw new Exception("用户信息不存在");
            }
            if (usr.Password != encryptPassword)
            {
                throw new Exception("原密码不正确");
            }
            usr.Password = NHExt.Runtime.Util.EncryptHelper.Encrypt(this.Password);
            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
