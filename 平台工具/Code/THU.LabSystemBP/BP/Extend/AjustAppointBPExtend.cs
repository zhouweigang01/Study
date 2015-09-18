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
                throw new Exception("����������ڣ�ԤԼ��ʼʱ������ڵ�ǰʱ�������Ժ�");
            }

            THU.LabSystemBE.DeviceUseRecord useRecord = THU.LabSystemBE.DeviceUseRecord.Finder.FindById(this.ID);
            if (useRecord == null)
            {
                throw new Exception("ԤԼ��¼������:" + this.ID);
            }
            //ԤԼ�����ڵĻ��������޸Ŀ�ʼԤԼ��ʼʱ��
            if (this.BeginTime != useRecord.BeginTime)
            {
                ts = useRecord.BeginTime - DateTime.Now;
                if (ts.TotalDays <= 3 && usr.Type != THU.LabSystemBE.UserTypeEnum.Admin)
                {
                    throw new Exception("ԤԼ��¼��ԤԼ��ʼʱ���ڵ�ǰʱ������֮�ڣ�ԤԼ��ʼʱ���޸�ʧ��");
                }
            }

            if (!useRecord.IsAppoint)
            {
                throw new Exception("��ǰ���ݲ���ԤԼ���ݣ��޷�����:" + this.ID);
            }
            //��ѯ��ǰ��û��ԤԼ��¼
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
                throw new Exception("��ǰʱ���豸��" + dvRecord.Device.SN + "����ʱ�䡰" + dvRecord.BeginTime.ToString("yyyy-MM-dd HH:mm") + "������" + dvRecord.EndTime.Value.ToString("yyyy-MM-dd HH:mm") + "��" + "�Ѿ���ԤԼ��ԤԼʧ��");
            }
            if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin && usr.ID != useRecord.User.ID)
            {
                throw new Exception("��ǰ�û�û���޸ĵ�ǰ���ݵ�Ȩ��");
            }
            useRecord.BeginTime = this.BeginTime;
            useRecord.EndTime = this.EndTime;

            NHExt.Runtime.Session.Session.Current.Commit();

            return true;
        }
    }
}
