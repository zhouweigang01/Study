using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertUserBP
    {
        private THU.LabSystemBE.Deploy.UserDTO DoExtend()
        {
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Create();
            usr.FromDTO(this.UserDTO);
            usr.Password = NHExt.Runtime.Util.EncryptHelper.Encrypt(this.UserDTO.Password);
            NHExt.Runtime.Session.Session.Current.Commit();
            return usr.ToDTO();
        }
    }
}
