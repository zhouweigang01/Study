using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class CommonEnum
    {

        private void FromDTOImpl(Deploy.CommonEnumDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.CommonEnumDTO dto)
        {

        }
        private void OnSetDefaultValue()
        {

        }
        private void OnValidate()
        {
            User usr = User.Finder.FindById(NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID);
            if (usr == null)
            {
                throw new Exception("��ǰ��½�û���Ϣ������");
            }
            if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin)
            {
                throw new Exception("��ǰ�û����ǹ���Ա���޷��༭ö����Ϣ");
            }
            if (this.Type == null || this.Type.EnumValue <= 0)
            {
                throw new Exception("ö�����Ͳ���Ϊ��");
            }
            if (string.IsNullOrEmpty(this.Code))
            {
                throw new Exception("ö�����ͱ��벻��Ϊ��");
            }
            string hql = "Type=${0} and Code=${1}$ and ID !=${2}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.Type);
            paramList.Add(this.Code);
            paramList.Add(this.ID);
            CommonEnum ce = CommonEnum.Finder.Find(hql, paramList);
            if (ce != null)
            {
                throw new Exception("����Ϊ��" + this.Code + "����ö�������Ѿ�����");
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

