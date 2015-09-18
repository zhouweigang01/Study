using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetEnumListBP
    {
        private List<THU.LabSystemBE.Deploy.CommonEnumDTO> DoExtend()
        {
            string hql = "Type=${0}$ and IsDelete=0";
            List<object> paramList = new List<object>();
            paramList.Add(this.Type);
            List<THU.LabSystemBE.CommonEnum> ceList = THU.LabSystemBE.CommonEnum.Finder.FindAll(hql, paramList);
            List<THU.LabSystemBE.Deploy.CommonEnumDTO> ceDTOList = new List<LabSystemBE.Deploy.CommonEnumDTO>();
            foreach (THU.LabSystemBE.CommonEnum ce in ceList)
            {
                ceDTOList.Add(ce.ToDTO());
            }
            return ceDTOList;
        }
    }
}
