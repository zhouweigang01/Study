using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class Teacher
    {

        private void FromDTOImpl(Deploy.TeacherDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.TeacherDTO dto)
        {
            if (this.Sex != null)
            {
                dto.SexName = this.Sex.Name;
            }
            if (this.Position != null)
            {
                dto.PositionName = this.Position.Name;
            }
            if (this.Department != null)
            {
                dto.DepartmentName = this.Department.Name;
            }
        }
        private void OnSetDefaultValue()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                this.Tag = Util.SpellChar.GetSpellCode(this.Name);
            }
        }
        private void OnValidate()
        {

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

