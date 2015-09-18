using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetUserListBP
    {
        private THU.LabSystemBE.Deploy.UserExDTO DoExtend()
        {
            string hql = "Type=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.Type);
            if (this.ID > 0)
            {
                hql += " and ID=${1}$";
                paramList.Add(this.ID);
            }
            List<THU.LabSystemBE.User> usrList = THU.LabSystemBE.User.Finder.FindAll(hql, paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
            THU.LabSystemBE.Deploy.UserExDTO usrExDTO = new LabSystemBE.Deploy.UserExDTO();
            usrExDTO.ListData = new List<LabSystemBE.Deploy.UserDTO>();
            foreach (THU.LabSystemBE.User usr in usrList)
            {
                usrExDTO.ListData.Add(usr.ToDTO());
            }
            usrExDTO.ListCount = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.User>(hql, paramList) ?? 0;
            return usrExDTO;
        }
    }
}
