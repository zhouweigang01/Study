using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ModifyUserBP
    {
        private THU.LabSystemBE.Deploy.UserDTO DoExtend()
        {
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(this.UserDTO.ID);
            if (usr == null)
            {
                throw new Exception("用户信息不存在");
            }
            string passwordStr = usr.Password;
            THU.LabSystemBE.UserTypeEnum usrType = usr.Type;
            usr.FromDTO(this.UserDTO);
            if (passwordStr != usr.Password)
            {
                THU.LabSystemBE.User logUser = THU.LabSystemBE.User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
                if (logUser.Type != THU.LabSystemBE.UserTypeEnum.Admin)
                {
                    usr.Password = passwordStr;
                }
                else
                {
                    usr.Password = NHExt.Runtime.Util.EncryptHelper.Encrypt(usr.Password);
                }
            }
            usr.Type = usrType;
            NHExt.Runtime.Session.Session.Current.Commit();
            return usr.ToDTO();
        }
    }
}
