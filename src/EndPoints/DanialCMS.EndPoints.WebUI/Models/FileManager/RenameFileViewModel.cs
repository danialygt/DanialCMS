using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.FileManager
{
    public class RenameFileViewModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "نام")]
        [MaxLength(30, ErrorMessage = "نام باید کمتر از 30 کاراکتر باشد")]
        public string Name { get; set; }
    }
}
