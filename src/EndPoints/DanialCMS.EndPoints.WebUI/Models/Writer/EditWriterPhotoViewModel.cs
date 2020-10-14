using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Writer
{
    public class EditWriterPhotoViewModel
    {
        [Required]
        public long WriterId { get; set; }

        [Required(ErrorMessage = "عکس را انتخاب کنید")]
        [Display(Name = "عکس")]
        public IFormFile File { get; set; }
    }
}
