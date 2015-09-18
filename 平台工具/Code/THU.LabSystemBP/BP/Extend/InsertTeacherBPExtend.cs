using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertTeacherBP
    {
        private THU.LabSystemBE.Deploy.TeacherDTO DoExtend()
        {
            THU.LabSystemBE.Teacher teacher = THU.LabSystemBE.Teacher.Create();
            teacher.FromDTO(this.TeacherDTO);
            NHExt.Runtime.Session.Session.Current.Commit();
            return teacher.ToDTO();
        }
    }
}
