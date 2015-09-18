using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class AjustAppointBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            TimeSpan ts = this.BeginTime - DateTime.Now;
            if (ts.TotalDays <= 3 && usr.Type != THU.LabSystemBE.UserTypeEnum.Admin)
            {
                throw new Exception("调整后的日期，预约开始时间必须在当前时间三天以后");
            }

            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.FindById(this.ID);
            if (useRecord == null)
            {
                throw new Exception("预约记录不存在:" + this.ID);
            }
            //预约三天内的话则不允许修改开始预约开始时间
            if (this.BeginTime != useRecord.BeginTime)
            {
                ts = useRecord.BeginTime - DateTime.Now;
                if (ts.TotalDays <= 3 && usr.Type != THU.LabSystemBE.UserTypeEnum.Admin)
                {
                    throw new Exception("预约记录的预约开始时间在当前时间三天之内，预约开始时间修改失败");
                }
            }

            if (!useRecord.IsAppoint)
            {
                throw new Exception("当前数据不是预约数据，无法调整:" + this.ID);
            }
            //查询当前有没有预约记录
            string hql = "((BeginTime>=${0}$ and BeginTime <= ${1}$) or (EndTime>=${0}$ and EndTime <= ${1}$) or (BeginTime<=${0}$ and EndTime >= ${1}$)) and IsAppoint=1";
            hql += " and Device=${2}$ and ID !=${3}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.BeginTime);
            paramList.Add(this.EndTime);
            paramList.Add(useRecord.Device);
            paramList.Add(this.ID);
            THU.LabSystemBE.DeviceUseRecord dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
            if (dvRecord != null && useRecord.Device.Device.Type == THU.LabSystemBE.DeviceTypeEnum.Single)
            {
                throw new Exception("当前时间设备“" + dvRecord.Device.SN + "”在时间“" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "”至“" + dvRecord.EndTime.Value.ToString("yyyy-MM-dd HH:mm") + "”" + "已经被预约，预约失败");
            }
            if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin && usr.ID != useRecord.User.ID)
            {
                throw new Exception("当前用户没有修改当前数据的权限");
            }
            useRecord.BeginTime = this.BeginTime;
            useRecord.EndTime = this.EndTime;

            NHExt.Runtime.Session.Session.Current.Commit();

            return true;
        }
    }
}
