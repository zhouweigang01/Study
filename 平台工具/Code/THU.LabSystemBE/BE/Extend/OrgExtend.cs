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
                throw new Exception("当前用户没有登录修改用户信息失败");
            }
            if (logUsr.Type != UserTypeEnum.Super)
            {
                throw new Exception("当前用户没有修改组织信息的权限");
            }

            if (string.IsNullOrEmpty(this.Code))
            {
                throw new Exception("枚举类型编码不能为空");
            }
            string hql = "Code=${0}$ and ID !=${1}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.Code);
            paramList.Add(this.ID);
            CommonEnum ce = CommonEnum.Finder.Find(hql, paramList);
            if (ce != null)
            {
                throw new Exception("编码为“" + this.Code + "”的组织已经存在");
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

