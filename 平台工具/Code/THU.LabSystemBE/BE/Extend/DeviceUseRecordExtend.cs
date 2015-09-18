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
            //ͼ��������ʾʹ��
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
                    NHExt.Runtime.Logger.LoggerHelper.Error("��ʽ" + this.Device.Expression + "��ʽ����,������Ĺ�ʽΪ��" + expression);
                    throw new Exception("���ü��㹫ʽ����");
                }
            }
            return 0;
        }
        private void OnValidate()
        {
            if (this.IsAppoint && this.EndTime == null)
            {
                throw new Exception("ԤԼ�豸ʹ�ý���ʱ�䲻��Ϊ��");
            }
            if (this.EndTime != null && this.EndTime <= this.BeginTime)
            {
                throw new Exception("�豸ʹ�ý���ʱ���������豸ʹ�õĿ�ʼʱ��");
            }

            if (this.EntityState != NHExt.Runtime.Enums.EntityState.Add)
            {
                if (this.IsCompleted && this.IsCompleted == this.OrignalData.IsCompleted)
                {
                    throw new Exception("��ǰ�豸ʹ�ü�¼�Ѿ�����������ʧ��");
                }
            }

        }
        private void OnInserting()
        {
            if (this.IsAppoint)
            {
                if (this.BeginTime <= DateTime.Now)
                {
                    throw new Exception("ԤԼ�������뿪ʼʱ�������ڵ�ǰʱ��");
                }
                this.IsUsing = false;
            }
            else
            {
                this.IsUsing = true;
            }
            if (this.Device.DeviceStatus == DeviceStatusEnum.Discard)
            {
                throw new Exception("�豸��" + this.Device.Device.Name + "���Ѿ����ϣ��޷�ԤԼ");
            }
            //��ѯ��ǰ��û��ԤԼ��¼
            if (this.Device.Device.Type == THU.LabSystemBE.DeviceTypeEnum.Single)
            {
                DeviceUseRecord dvRecord = null;
                DeviceMap deviceMap = this.Device;
                string hql = string.Empty;
                List<object> paramList = new List<object>();
                if (this.IsAppoint)
                {
                    //��ǰʱ�����û��ԤԼ��¼
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
                        throw new Exception("��ǰʱ���豸��" + deviceMap.SN + "����ʱ�䡰" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "������" + dvRecord.EndTime.Value.ToString("yyyy-MM-dd HH:mm") + "��" + "�Ѿ���ԤԼ");
                    }
                }
                else
                {
                    //�жϵ�ǰʱ����û��û�����ʹ�õ�ԤԼ��¼
                    hql = "BeginTime<=${0}$ and EndTime>${0}$ and Device=${1}$ and ID!=${2}$ and IsAppoint=1  and IsCompleted=0";
                    paramList.Clear();
                    paramList.Add(this.BeginTime);
                    paramList.Add(this.Device.ID);
                    paramList.Add(this.ID);
                    dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
                    if (dvRecord != null)
                    {
                        throw new Exception("��ǰʱ���豸��" + deviceMap.SN + "����ʱ�䡰" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "������" + dvRecord.EndTime.Value.ToString("yyyy-MM-dd HH:mm") + "��" + "�Ѿ���ԤԼ");
                    }
                }

                ///�Ƿ�������ʹ�õļ�¼
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
                        throw new Exception("��ǰʱ���豸��" + deviceMap.SN + "����ʱ�䡰" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "�����ڱ�ʹ��,��ǰʱ��24Сʱ���޷�ԤԼʹ��");
                    }
                }

                ///�Ƿ����Ѿ����ʹ�õļ�¼
                hql = "BeginTime<=${0}$ and EndTime>${0}$ and Device=${1}$ and ID!=${2}$ and IsAppoint=0 and IsCompleted=1";
                paramList.Clear();
                paramList.Add(this.BeginTime);
                paramList.Add(this.Device.ID);
                paramList.Add(this.ID);
                dvRecord = THU.LabSystemBE.DeviceUseRecord.Finder.Find(hql, paramList);
                if (dvRecord != null)
                {
                    throw new Exception("��ǰʱ���豸��" + deviceMap.SN + "����ʱ�䡰" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "�����ڱ�ʹ��");
                }
            }


            this.Teacher = this.User.Teacher;
            this.House = this.Device.House;
            //ֻ������ʹ�õ��豸����Ҫ�������
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
                            throw new Exception("��ǰ�û�û���޸ĵ�ǰ���ݵ�Ȩ��");
                        }
                        if (this.BeginTime != this.OrignalData.BeginTime && usr.Type != UserTypeEnum.Admin)
                        {
                            throw new Exception("ԤԼ�豸ʹ���豸ʹ��ǰ����ֻ�����ӳ��豸ԤԼ����ʱ��");
                        }
                    }
                }
            }
            //ֻ������ʹ�õ��豸����Ҫ�������
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
            //����device״̬
            if (!this.IsAppoint)
            {
                string hql = "Device=${0}$ and IsCompleted=0 and IsAppoint=0 and ID !=${1}$";
                List<object> paramList = new List<object>();
                paramList.Add(this.Device);
                paramList.Add(this.ID);
                DeviceUseRecord record = DeviceUseRecord.Finder.Find(hql, paramList);
                if (record == null)
                {
                    //�鿴��û��ԤԼʹ�õ�����
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
                            throw new Exception("��ǰ�û�û���޸ĵ�ǰ���ݵ�Ȩ��");
                        }
                        if (usr.Type != UserTypeEnum.Admin)
                        {
                            throw new Exception("ԤԼ�豸ʹ���豸ʹ��ǰ���첻����ȡ��ԤԼ");
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

