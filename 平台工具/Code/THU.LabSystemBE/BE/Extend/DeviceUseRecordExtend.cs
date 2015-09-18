using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class DeviceUseRecord
    {

        private void FromDTOImpl(Deploy.DeviceUseRecordDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.DeviceUseRecordDTO dto)
        {

            if (this.IsAppoint || this.IsCompleted)
            {
                dto.TotalHours = (this.EndTime.Value - this.BeginTime).TotalHours;
            }
            else
            {
                dto.TotalHours = (DateTime.Now - this.BeginTime).TotalHours;
            }
            dto.TotalHours = Math.Round(dto.TotalHours, 2);
            dto.DeviceStatusName = this.Device.DeviceStatus.Name;
            dto.DeviceUseStatusName = this.Device.UseStatus.Name;
            dto.UseStatusName = this.Device.UseStatus.Name;
            dto.UserName = this.User.Name;
            dto.UserTel = this.User.Tel;
            dto.DeviceSN = this.Device.SN;
            dto.DeviceName = this.Device.Device.Name;
            dto.HouseName = this.House.Name;
            //图表上面显示使用
            dto.BeginDateStr = this.BeginTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (this.EndTime != null)
            {
                dto.EndDateStr = this.EndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (this.IsAppoint && !this.IsCompleted)
            {
                TimeSpan ts = this.BeginTime - DateTime.Now;
                if (ts.Days > 3)
                {
                    dto.CanAppoint = true;
                }
            }
        }
        private void OnSetDefaultValue()
        {
            this.Price = this.Device.Price ?? 0;

        }

        private decimal CalcExpression(TimeSpan ts, string expression)
        {
            if (!string.IsNullOrEmpty(expression))
            {
                expression = expression.Replace("Days", Math.Round(ts.TotalDays, 2).ToString());
                expression = expression.Replace("Hours", Math.Round(ts.TotalHours, 2).ToString());
                expression = expression.Replace("Minutes", Math.Round(ts.TotalMinutes, 2).ToString());
                expression = expression.Replace("Price", this.Price.ToString());
                expression = expression.Replace("Day", ts.Days.ToString());
                expression = expression.Replace("Hour", ts.Hours.ToString());
                expression = expression.Replace("Minute", ts.Minutes.ToString());
                NHExt.Runtime.Util.RPN rpn = new NHExt.Runtime.Util.RPN();
                try
                {
                    rpn.Parse(expression);

                    return Convert.ToDecimal(rpn.Evaluate());
                }
                catch
                {
                    NHExt.Runtime.Logger.LoggerHelper.Error("公式" + this.Device.Expression + "公式错误,解析后的公式为：" + expression);
                    throw new Exception("费用计算公式错误");
                }
            }
            return 0;
        }
        private void OnValidate()
        {
            if (this.IsAppoint && this.EndTime == null)
            {
                throw new Exception("预约设备使用结束时间不能为空");
            }
            if (this.EndTime != null && this.EndTime <= this.BeginTime)
            {
                throw new Exception("设备使用结束时间必须大于设备使用的开始时间");
            }

            if (this.EntityState != NHExt.Runtime.Enums.EntityState.Add)
            {
                if (this.IsCompleted && this.IsCompleted == this.OrignalData.IsCompleted)
                {
                    throw new Exception("当前设备使用记录已经结束，操作失败");
                }
            }

        }
        private void OnInserting()
        {
            if (this.IsAppoint)
            {
                if (this.BeginTime <= DateTime.Now)
                {
                    throw new Exception("预约申请申请开始时间必须大于当前时间");
                }
                this.IsUsing = false;
            }
            else
            {
                this.IsUsing = true;
            }
            if (this.Device.DeviceStatus == DeviceStatusEnum.Discard)
            {
                throw new Exception("设备“" + this.Device.Device.Name + "”已经报废，无法预约");
            }
            //查询当前有没有预约记录
            if (this.Device.Device.Type == THU.LabSystemBE.DeviceTypeEnum.Single)
            {
                DeviceUseRecord dvRecord = null;
                DeviceMap deviceMap = this.Device;
                string hql = string.Empty;
                List<object> paramList = new List<object>();
                if (this.IsAppoint)
                {
                    //当前时间段有没有预约记录
                    hql = "((BeginTime<=${0}$ and EndTime>${0}$) or (BeginTime<${1}$ and EndTime>=${1}$) or (BeginTime>=${0}$ and EndTime<=${1}$)) ";
                    hql += " and Device=${2}$ and ID !=${3}$ and IsAppoint=1 and IsCompleted=0";
                    paramList.Clear();
                    paramList.Add(this.BeginTime);
                    paramList.Add(this.EndTime);
                    paramList.Add(this.Device.ID);
                    paramList.Add(this.ID);
                    dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
                    if (dvRecord != null)
                    {
                        throw new Exception("当前时间设备“" + deviceMap.SN + "”在时间“" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "”至“" + dvRecord.EndTime.Value.ToString("yyyy-MM-dd HH:mm") + "”" + "已经被预约");
                    }
                }
                else
                {
                    //判断当前时间有没有没有完成使用的预约记录
                    hql = "BeginTime<=${0}$ and EndTime>${0}$ and Device=${1}$ and ID!=${2}$ and IsAppoint=1  and IsCompleted=0";
                    paramList.Clear();
                    paramList.Add(this.BeginTime);
                    paramList.Add(this.Device.ID);
                    paramList.Add(this.ID);
                    dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
                    if (dvRecord != null)
                    {
                        throw new Exception("当前时间设备“" + deviceMap.SN + "”在时间“" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "”至“" + dvRecord.EndTime.Value.ToString("yyyy-MM-dd HH:mm") + "”" + "已经被预约");
                    }
                }

                ///是否有正在使用的记录
                hql = "BeginTime<=${0}$ and Device=${1}$ and ID!=${2}$ and IsAppoint=0 and IsCompleted=0";
                paramList.Clear();
                paramList.Add(this.BeginTime);
                paramList.Add(this.Device.ID);
                paramList.Add(this.ID);
                dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
                if (dvRecord != null)
                {
                    if ((this.BeginTime - dvRecord.BeginTime).TotalHours < 24)
                    {
                        throw new Exception("当前时间设备“" + deviceMap.SN + "”在时间“" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "”正在被使用,当前时间24小时内无法预约使用");
                    }
                }

                ///是否有已经完成使用的记录
                hql = "BeginTime<=${0}$ and EndTime>${0}$ and Device=${1}$ and ID!=${2}$ and IsAppoint=0 and IsCompleted=1";
                paramList.Clear();
                paramList.Add(this.BeginTime);
                paramList.Add(this.Device.ID);
                paramList.Add(this.ID);
                dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
                if (dvRecord != null)
                {
                    throw new Exception("当前时间设备“" + deviceMap.SN + "”在时间“" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "”正在被使用");
                }
            }


            this.Teacher = this.User.Teacher;
            this.House = this.Device.House;
            //只有正常使用的设备才需要计算费用
            if (this.IsAppoint || this.IsCompleted)
            {
                if (this.IsCompleted && this.EndTime == null)
                {
                    this.EndTime = DateTime.Now;
                }
                TimeSpan ts = this.EndTime.Value - this.BeginTime;
                this.Fee = this.CalcExpression(ts, this.Device.Expression);
                this.TotalTime = Math.Round(ts.TotalHours, 2);
            }
            else
            {
                this.Fee = 0;
            }
        }
        private void OnInserted()
        {

        }
        private void OnUpdating()
        {
            if (this.IsCompleted)
            {
                this.IsUsing = false;
            }
            if (this.IsAppoint && !this.IsCompleted)
            {
                TimeSpan ts = this.BeginTime - DateTime.Now;
                if (ts.TotalDays < 3)
                {
                    if (NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID > 0)
                    {
                        THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
                        if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin && usr.ID != this.User.ID)
                        {
                            throw new Exception("当前用户没有修改当前数据的权限");
                        }
                        if (this.BeginTime != this.OrignalData.BeginTime && usr.Type != UserTypeEnum.Admin)
                        {
                            throw new Exception("预约设备使用设备使用前三天只允许延长设备预约结束时间");
                        }
                    }
                }
            }
            //只有正常使用的设备才需要计算费用
            if (this.IsAppoint || this.IsCompleted)
            {
                if (this.IsCompleted && this.EndTime == null)
                {
                    this.EndTime = DateTime.Now;
                }
                TimeSpan ts = this.EndTime.Value - this.BeginTime;
                this.Fee = this.CalcExpression(ts, this.Device.Expression);
                this.Fee = Math.Round(this.Fee, 2);
                this.TotalTime = Math.Round(ts.TotalHours, 2);
            }
            else
            {
                this.Fee = 0;
            }
        }
        private void OnUpdated()
        {
            //更新device状态
            if (!this.IsAppoint)
            {
                string hql = "Device=${0}$ and IsCompleted=0 and IsAppoint=0 and ID !=${1}$";
                List<object> paramList = new List<object>();
                paramList.Add(this.Device);
                paramList.Add(this.ID);
                DeviceUseRecord record = DeviceUseRecord.Finder.Find(hql, paramList);
                if (record == null)
                {
                    //查看有没有预约使用的数据
                    hql = "Device=${0}$ and IsCompleted=0 and IsAppoint=1 and BeginTime<=${1}$ and EndTime>=${1}$";
                    paramList.Clear();
                    paramList.Add(this.Device);
                    paramList.Add(DateTime.Now);
                    record = DeviceUseRecord.Finder.Find(hql, paramList);
                    if (record == null)
                    {
                        this.Device.UseStatus = UseStatusEnum.Idle;
                    }
                }
            }

        }
        private void OnDeleting()
        {
            if (this.IsAppoint && !this.IsCompleted)
            {
                TimeSpan ts = this.BeginTime - DateTime.Now;
                if (ts.TotalDays < 3)
                {
                    if (NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID > 0)
                    {
                        THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
                        if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin && usr.ID != this.User.ID)
                        {
                            throw new Exception("当前用户没有修改当前数据的权限");
                        }
                        if (usr.Type != UserTypeEnum.Admin)
                        {
                            throw new Exception("预约设备使用设备使用前三天不允许取消预约");
                        }
                    }
                }
            }
        }
        private void OnDeleted()
        {

        }



    }
}

