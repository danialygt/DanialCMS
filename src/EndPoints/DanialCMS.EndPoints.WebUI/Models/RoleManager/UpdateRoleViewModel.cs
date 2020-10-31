using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.RoleManager
{
    public class UpdateRoleViewModel
    {
        public string Id { get; set; }
        public string OldName { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string Name { get; set; }
    }
}
