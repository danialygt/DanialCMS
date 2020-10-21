using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.FileManagements.Entities
{
    public class FileManagement
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public DateTime Date { get; set; }

    }
}
