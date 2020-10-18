using DanialCMS.Core.Domain.Contents.Entities;
using System.Collections.Generic;

namespace DanialCMS.Core.Domain.Writers.Dtos
{
    public class DtoWriterDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public List<Content> Contents { get; set; }

    }
}
