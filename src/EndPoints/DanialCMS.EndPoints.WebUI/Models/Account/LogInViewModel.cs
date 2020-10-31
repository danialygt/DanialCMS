using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Account
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "ایمیل یا نام کاربری را وارد کنید")]
        [Display(Name = "ایمیل یا نام کاربری")]
        public string EmailOrUsername { get; set; }


        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
