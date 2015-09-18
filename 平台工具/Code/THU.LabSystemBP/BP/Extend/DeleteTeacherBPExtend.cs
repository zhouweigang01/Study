using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class DeleteTeacherBP
    {
        private bool DoExtend()
        {
            THU.LabSystemBE.Teacher teacher = THU.LabSystemBE.Teacher.Finder.FindById(this.ID);
            if (teacher == null)
            {
                throw new Exception("教师信息不存在");
            }

            string hql = "Teacher=${0}$";
            List<object> paramList = new List<object>();
            paramList.Add(this.ID);
            THU.LabSystemBE.User usr = THU.LabSystemBE.User.Finder.Find(hql, paramList);

            if (usr == null)
            {
                NHExt.Runtime.Session.Session.Current.Remove(teacher);
            }
            else
            {
                teacher.IsDelete = true;
            }
            NHExt.Runtime.Session.Session.Current.Commit();
            return true;
        }
    }
}
