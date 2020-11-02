using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.RoleManager
{
    public class AddRoleViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد کنید")]
        [MaxLength(256, ErrorMessage = "نام باید کمتر از 256 کاراکتر باشد ")]
        public string Name { get; set; }
    }
}
