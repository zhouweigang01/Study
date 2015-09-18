using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class User
    {

        private void FromDTOImpl(Deploy.UserDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.UserDTO dto)
        {
            if (this.Teacher != null)
            {
                dto.TeacherName = this.Teacher.Name;
            }
            if (this.Degree != null)
            {
                dto.DegreeName = this.Degree.Name;
            }
            if (this.Status != null)
            {
                dto.StatusName = this.Status.Name;
            }
        }
        private void OnSetDefaultValue()
        {
            if (string.IsNullOrEmpty(this.SN))
            {
                this.SN = string.Empty;
            }
            if (string.IsNullOrEmpty(this.Name))
            {
                this.Name = string.Empty;
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                this.Email = string.Empty;
            }

        }
        private void OnValidate()
        {
            if (NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID != this.ID)
            {
                User logUsr = User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
                if (logUsr == null)
                {
                    User usrTemp = User.Finder.Find("1=1");
                    if (usrTemp != null)
                    {
                        throw new Exception("��ǰ�û�û�е�¼���޸��û���Ϣʧ��");
                    }
                }
                else if (logUsr.Type == UserTypeEnum.User)
                {
                    throw new Exception("��ǰ�û�û���޸��û���Ϣ��Ȩ��");
                }
            }
            //��ͨ�û�����Ҫ��д������
            if (this.Type == UserTypeEnum.User)
            {
                if (string.IsNullOrEmpty(this.SN))
                {
                    throw new Exception("ѧ�Ų���Ϊ��");
                }
            }

            string hql = "(SN=${0}$ or Email=${1}$ or Code=${2}$) and ID != ${3}$ and IsDelete=0";
            List<object> paramList = new List<object>();
            paramList.Add(this.SN);
            paramList.Add(this.Email);
            paramList.Add(this.Code);
            paramList.Add(this.ID);
            User usr = User.Finder.Find(hql, paramList);
            if (usr != null)
            {
                if (usr.Code == this.Code)
                {
                    throw new Exception("��¼��Ϊ��" + this.Code + "�����û��Ѿ�����");
                }
                if (usr.Email == this.Email && !string.IsNullOrEmpty(this.Email))
                {
                    throw new Exception("����Ϊ��" + this.Email + "�����û��Ѿ�����");
                }
                if (usr.SN == this.SN && !string.IsNullOrEmpty(this.SN))
                {
                    throw new Exception("ѧ����Ϊ��" + this.SN + "�����û��Ѿ�����");
                }
            }
        }
        private void OnInserting()
        {
            if (this.Type == UserTypeEnum.Admin)
            {
                User usr = User.Finder.Find("1=1");
                if (usr != null)
                {
                    throw new Exception("ϵͳ�Ѿ�������֯����Ա��������֯����Աʧ��");
                }
            }
            else if (this.Type == UserTypeEnum.User)
            {
                User usr = User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
                if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin)
                {
                    throw new Exception("��ǰ�������ǹ���Ա���޷��½��û�");
                }
            }
        }
        private void OnInserted()
        {

        }
        private void OnUpdating()
        {
            if (this.IsDelete && this.IsDelete == this.OrignalData.IsDelete)
            {
                throw new Exception("�Ѿ�ɾ���û������޸�");
            }
            if (this.Type != this.OrignalData.Type)
            {
                throw new Exception("�û����Ͳ������޸�");
            }
        }
        private void OnUpdated()
        {

        }
        private void OnDeleting()
        {

        }
        private void OnDeleted()
        {

        }
    }
}

