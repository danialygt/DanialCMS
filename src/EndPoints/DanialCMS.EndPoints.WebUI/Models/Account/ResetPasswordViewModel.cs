using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Account
{
    public class ResetPasswordViewModel
    {
        public string Token { get; set; }
        public string Email { get; set; }



        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید")]
        public string RePassword { get; set; }
    }
}
