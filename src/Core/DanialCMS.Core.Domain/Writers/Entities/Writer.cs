using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Writers.Entities
{
    public class Writer
    {
        public long Id { get; set; }
        public List<Content> Contents { get; set; }


    }
}
