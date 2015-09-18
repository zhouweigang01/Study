using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class Device
    {

        private void FromDTOImpl(Deploy.DeviceDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.DeviceDTO dto)
        {
            dto.TypeName = this.Type.Name;
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

