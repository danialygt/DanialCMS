using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.User
{
    public class AddUserToRoleViewModel
    {
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(256, ErrorMessage = "نام کاربری باید کمتر از 256 کاراکتر باشد ")]
        public string UserName { get; set; }

        [Display(Name = "نقش ها")]
        [Required(ErrorMessage = "حداقل یک نقش انتخاب کنید")]
        public List<string> RolesName { get; set; } = new List<string>();


        public List<string> AllRoles { get; set; } = new List<string>();

        public List<SelectListItem> GetAllRolesListItems()
        {
            var result =
            AllRoles.Select(role => new SelectListItem
            {
                Value = role,
                Text = role,
            }).ToList();
            return result;
        }



    }
}
