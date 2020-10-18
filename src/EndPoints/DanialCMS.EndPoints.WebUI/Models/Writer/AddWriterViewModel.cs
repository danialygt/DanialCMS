using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Writer
{
    public class AddWriterViewModel
    {
        [Required(ErrorMessage = "نام نویسنده را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(30)]
        public string Name { get; set; }


        
        [Display(Name = "عکس")]
        public IFormFile? file { get; set; }
    }
}
