using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace THU.LabSystemBE
{
    public partial class LoginLogger
    {

        private void FromDTOImpl(Deploy.LoginLoggerDTO dto)
        {

        }
        private void ToDTOImpl(Deploy.LoginLoggerDTO dto)
        {

        }
        private void OnSetDefaultValue()
        {
            if (!string.IsNullOrEmpty(this.ErrorMsg))
            {
                this.Success = false;
            }
            else
            {
                this.Success = true;
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

