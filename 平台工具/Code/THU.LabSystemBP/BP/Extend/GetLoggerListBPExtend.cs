using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetLoggerListBP
    {
        private THU.LabSystemBE.Deploy.LoggerExDTO DoExtend()
        {
            string hql = "User=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.UserKey);

            List<THU.LabSystemBE.LoginLogger> loggerList = THU.LabSystemBE.LoginLogger.Finder.FindAll(hql + " order by LoginDate desc", paramList, (this.PageIndex - 1) * this.PageSize, this.PageSize);
            THU.LabSystemBE.Deploy.LoggerExDTO loggerExDTO = new LabSystemBE.Deploy.LoggerExDTO();
            loggerExDTO.ListData = new List<LabSystemBE.Deploy.LoginLoggerDTO>();
            foreach (THU.LabSystemBE.LoginLogger logger in loggerList)
            {
                loggerExDTO.ListData.Add(logger.ToDTO());
            }
            loggerExDTO.ListCount = NHExt.Runtime.Query.EntityFinder.Count<THU.LabSystemBE.LoginLogger>(hql, paramList) ?? 0;
            return loggerExDTO;
        }
    }
}
