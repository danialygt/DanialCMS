using DanialCMS.Core.Domain.Editors.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Entities
{
    public class ContentEditors
    {
        public long Id { get; set; }
        public long ContentId { get; set; }
        public Content Content { get; set; }
        public long EditorId { get; set; }
        public Editor Editor { get; set; }
    }
}
