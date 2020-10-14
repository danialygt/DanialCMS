using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
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

        public string Name { get; set; }


        public long PhotoId { get; set; }

   
        public string PhotoUrl { get; set; }
    }
}
