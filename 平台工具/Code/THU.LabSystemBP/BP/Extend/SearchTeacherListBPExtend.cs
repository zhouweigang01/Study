using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class SearchTeacherListBP
    {
        private List<THU.LabSystemBE.Deploy.TeacherDTO> DoExtend()
        {
            List<THU.LabSystemBE.Deploy.TeacherDTO> teacherDTOList = new List<LabSystemBE.Deploy.TeacherDTO>();
            if (string.IsNullOrEmpty(this.SearchTxt))
            {
                return teacherDTOList;
            }
            List<object> paramList = new List<object>();
            string hql = "(";
            if (this.AttrubuteList != null)
            {
                foreach (string attr in this.AttrubuteList)
                {
                    hql += attr + " like ${0}$ or ";
                }
                paramList.Add(this.SearchTxt + "%");
            }
            hql += " 1!=1 ) and IsDelete=0";
            List<THU.LabSystemBE.Teacher> teacherList = THU.LabSystemBE.Teacher.Finder.FindAll(hql, paramList);
            foreach (THU.LabSystemBE.Teacher teacher in teacherList)
            {
                teacherDTOList.Add(teacher.ToDTO());
            }
            return teacherDTOList;
        }
    }
}
