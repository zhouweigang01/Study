using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class Org
    {

        private void FromDTOImpl(Deploy.OrgDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.OrgDTO dto)
        {

        }
        private void OnSetDefaultValue()
        {

        }
        private void OnValidate()
        {
            NHExt.Runtime.Session.Session.Current.IgnoreOrgFilter = true;
            User logUsr = User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (logUsr == null)
            {
                throw new Exception("��ǰ�û�û�е�¼�޸��û���Ϣʧ��");
            }
            if (logUsr.Type != UserTypeEnum.Super)
            {
                throw new Exception("��ǰ�û�û���޸���֯��Ϣ��Ȩ��");
            }

            if (string.IsNullOrEmpty(this.Code))
            {
                throw new Exception("ö�����ͱ��벻��Ϊ��");
            }
            string hql = "Code=${0}$ and ID !=${1}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.Code);
            paramList.Add(this.ID);
            CommonEnum ce = CommonEnum.Finder.Find(hql, paramList);
            if (ce != null)
            {
                throw new Exception("����Ϊ��" + this.Code + "������֯�Ѿ�����");
            }
        }
        private void OnInserting()
        {

        }
        private void OnInserted()
        {

        }
        private void OnUpdating()
        {

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

