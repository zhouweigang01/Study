using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetTeacherListBP
    {
	    private List<THU.LabSystemBE.Deploy.TeacherDTO> DoExtend()
        {
            List<THU.LabSystemBE.Teacher> teacherList = THU.LabSystemBE.Teacher.Finder.FindAll("1=1");
            List<THU.LabSystemBE.Deploy.TeacherDTO> teacherDTOList = new List<LabSystemBE.Deploy.TeacherDTO>();
            foreach (THU.LabSystemBE.Teacher teacher in teacherList)
            {
                teacherDTOList.Add(teacher.ToDTO());
            }
            return teacherDTOList;
        }
	}
}
