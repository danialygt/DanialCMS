using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Account
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل  وارد شده صحیح نمی باشد")]
        public string Email { get; set; }
    }
}
