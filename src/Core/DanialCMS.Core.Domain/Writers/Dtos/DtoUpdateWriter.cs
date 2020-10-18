using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Dtos
{
    public class DtoUpdateWriter
    {
        public string Name { get; set; }
        public long? PhotoId { get; set; }
        public string? PhotoUrl { get; set; }
   
    
    }
}
