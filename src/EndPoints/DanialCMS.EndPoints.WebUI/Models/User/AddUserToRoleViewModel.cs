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
