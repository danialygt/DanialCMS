using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.FileManager
{
    public class AddFileViewModel
    {
        [Display(Name = "فایل")]
        [Required]
        public List<IFormFile> Files { get; set; }
    }
}
