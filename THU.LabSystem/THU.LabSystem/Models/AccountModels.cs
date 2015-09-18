using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace THU.LabSystem.Models
{

    public class LogOnModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [Display(Name = "用户名")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}
