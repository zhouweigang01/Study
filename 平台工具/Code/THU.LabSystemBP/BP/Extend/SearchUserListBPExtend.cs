using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class SearchUserListBP
    {
        private List<THU.LabSystemBE.Deploy.UserDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.UserDTO> userDTOList = new List<LabSystemBE.Deploy.UserDTO>();
            if (string.IsNullOrEmpty(this.SearchTxt))
            {
                return userDTOList;
            }
            List<object> paramList = new List<object>();
            string hql = "(";
            if (this.AttrubuteList != null)
            {
                foreach (string attr in this.AttrubuteList)
                {
                    hql += attr + " like ${0}$ or ";
                }
                paramList.Add(this.SearchTxt + "%");
            }
            hql += " 1!=1 ) and IsDelete=0";
            List<THU.LabSystemBE.User> userList = THU.LabSystemBE.User.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.User user in userList)
            {
                userDTOList.Add(user.ToDTO());
            }
            return userDTOList;
        }
    }
}
