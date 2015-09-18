using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class ModifyTeacherBP
    {
        private THU.LabSystemBE.Deploy.TeacherDTO DoExtend()
        {
            THU.LabSystemBE.Teacher teacher = THU.LabSystemBE.Teacher.Finder.FindById(this.TeacherDTO.ID);
            if (teacher == null)
            {
                throw new Exception("组织信息不存在");
            }
            teacher.FromDTO(this.TeacherDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            return teacher.ToDTO();
        }
    }
}
