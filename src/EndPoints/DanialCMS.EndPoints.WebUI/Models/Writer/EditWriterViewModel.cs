using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Writer
{
    public class EditWriterViewModel
    {
 
        public long Id { get; set; }

        [Display(Name = "نام")]
        [MaxLength(30)]
        public string Name { get; set; }

        public long? PhotoId { get; set; }

   
        public string? PhotoUrl { get; set; }

        [Display(Name = "عکس")]
        public IFormFile File { get; set; }
        
    }
}
