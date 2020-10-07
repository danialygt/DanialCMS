using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Entities
{
    public class Content
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        public string Description { get; set; }

        public long PhotoId { get; set; }
        public FileManagement Photo { get; set; }

        public int Rate { get; set; }

        public ContentStatus ContentStatus { get; set; }


        public DateTime PublishDate { get; set; }
        public PublishPlace PublishPlace { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }


        public List<long> KeywordIds { get; set; }
        public List<Keyword> Keywords { get; set; }


        public long WriterId { get; set; }
        public Writer Writer { get; set; }



    }
}
