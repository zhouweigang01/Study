using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetGroupEnumListBP
    {
        private List<THU.LabSystemBE.Deploy.GroupEnumDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.GroupEnumDTO> geDTOList = new List<LabSystemBE.Deploy.GroupEnumDTO>();
            if (this.TypeList != null)
            {
                foreach (int type in this.TypeList)
                {
                    THU.LabSystemBE.Deploy.GroupEnumDTO geDTO = new LabSystemBE.Deploy.GroupEnumDTO();
                    geDTO.Type = type;
                    GetEnumListBP bp = new GetEnumListBP();
                    bp.Type = type;
                    geDTO.EnumList = bp.Do();
                    geDTOList.Add(geDTO);
                }
            }
            return geDTOList;
        }
    }
}
