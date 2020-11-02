using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Category
{
    public class UpdateCategoryViewModel
    {
        public long CategoryId { get; set; }

        [Required(ErrorMessage ="نام را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(50, ErrorMessage = "نام باید کمتر از 50 کاراکتر باشد")]
        public string Name { get; set; }
    }
}
