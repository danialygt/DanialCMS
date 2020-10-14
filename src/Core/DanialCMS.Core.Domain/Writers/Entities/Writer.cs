using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Entities
{
    public class Writer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? PhotoId { get; set; }
        public FileManagement Photo { get; set; }
        public List<Content> Contents { get; set; }


    }
}
