using DanialCMS.Core.Domain.Keywords.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Entities
{
    public class ContentKeywords
    {
        public long Id { get; set; }

        public long ContentId { get; set; }
        public Content Content { get; set; }
        public long KeywordId { get; set; }
        public Keyword Keyword { get; set; }

    }
}
