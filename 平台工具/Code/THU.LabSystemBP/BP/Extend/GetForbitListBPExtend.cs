using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetForbitListBP
    {
        private List<THU.LabSystemBE.Deploy.ForbidUserDTO> DoExtend()
        {
            string hql = "User=${0}$ order by StartTime desc";
            List<object> paramList = new List<object>();
            paramList.Add(this.UserKey);
            List<THU.LabSystemBE.ForbidUser> forbitList = THU.LabSystemBE.ForbidUser.Finder.FindAll(hql, paramList);
            List<THU.LabSystemBE.Deploy.ForbidUserDTO> forbitDTOList = new List<LabSystemBE.Deploy.ForbidUserDTO>();
            foreach (THU.LabSystemBE.ForbidUser forbit in forbitList)
            {
                forbitDTOList.Add(forbit.ToDTO());
            }
            return forbitDTOList;
        }
    }
}
