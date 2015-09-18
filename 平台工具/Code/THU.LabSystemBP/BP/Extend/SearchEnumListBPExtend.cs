using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class SearchEnumListBP
    {
        private List<THU.LabSystemBE.Deploy.CommonEnumDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.CommonEnumDTO> enumDTOList = new List<LabSystemBE.Deploy.CommonEnumDTO>();
            if (string.IsNullOrEmpty(this.SearchTxt))
            {
                return enumDTOList;
            }
            string hql = "Type=${0}$ and (Code like ${1}$ or Name like ${1}$) and IsDelete=0";
            List<object> paramList = new List<object>();
            paramList.Add(this.Type);
            paramList.Add("%" + this.SearchTxt + "%");
            List<THU.LabSystemBE.CommonEnum> enumList = THU.LabSystemBE.CommonEnum.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.CommonEnum ce in enumList)
            {
                enumDTOList.Add(ce.ToDTO());
            }
            return enumDTOList;
        }
    }
}
