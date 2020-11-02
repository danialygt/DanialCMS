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
        [MaxLength(256, ErrorMessage = "نام باید کمتر از 256 کاراکتر باشد ")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [MaxLength(256, ErrorMessage = "نام خانوادگی باید کمتر از 256 کاراکتر باشد ")]
        public string LastName { get; set; }




        [Display(Name = "ایمیل")]
        [MaxLength(256, ErrorMessage = "ایمیل باید کمتر از 256 کاراکتر باشد ")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }

        public string UserName { get; set; }

    }
}
