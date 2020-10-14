using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Writer
{
    public class EditWriterNameViewModel
    {
        [Required(ErrorMessage = "")]
        [Display(Name = "")]
        public long Id { get; set; }

        [Required(ErrorMessage = "نام جدید نویسنده را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
