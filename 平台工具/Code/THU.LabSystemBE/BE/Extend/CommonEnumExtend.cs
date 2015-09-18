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
                throw new Exception("当前登陆用户信息不存在");
            }
            if (usr.Type != THU.LabSystemBE.UserTypeEnum.Admin)
            {
                throw new Exception("当前用户不是管理员，无法编辑枚举信息");
            }
            if (this.Type == null || this.Type.EnumValue <= 0)
            {
                throw new Exception("枚举类型不能为空");
            }
            if (string.IsNullOrEmpty(this.Code))
            {
                throw new Exception("枚举类型编码不能为空");
            }
            string hql = "Type=${0} and Code=${1}$ and ID !=${2}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.Type);
            paramList.Add(this.Code);
            paramList.Add(this.ID);
            CommonEnum ce = CommonEnum.Finder.Find(hql, paramList);
            if (ce != null)
            {
                throw new Exception("编码为“" + this.Code + "”的枚举类型已经存在");
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

