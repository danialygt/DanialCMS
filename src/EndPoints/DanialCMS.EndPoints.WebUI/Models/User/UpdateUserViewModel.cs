using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.User
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }




        //[Required(ErrorMessage = "ایمیل را وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        //[Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        //[Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید")]
        public string RePassword { get; set; }

        public string UserName { get; set; }

    }
}
