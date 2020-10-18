using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Keyword
{
    public class AddKeywordViewModel
    {
        [Required(ErrorMessage = "نام را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(50)]
        public string Name { get; set; }
    }

}
