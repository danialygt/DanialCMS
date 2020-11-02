using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.User
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(256, ErrorMessage = "نام باید کمتر از 256 کاراکتر باشد ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(256, ErrorMessage = "نام خانوادگی باید کمتر از 256 کاراکتر باشد ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MaxLength(256, ErrorMessage = "نام کاربری باید کمتر از 256 کاراکتر باشد ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [Display(Name = "ایمیل")]
        [MaxLength(256, ErrorMessage = "ایمیل باید کمتر از 256 کاراکتر باشد ")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
