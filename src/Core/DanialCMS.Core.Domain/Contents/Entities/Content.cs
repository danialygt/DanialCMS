using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.Writers.Entities;
using System;
using System.Collections.Generic;

namespace DanialCMS.Core.Domain.Contents.Entities
{
    public class Content
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public long? PhotoId { get; set; }
        public FileManagement Photo { get; set; }
        public ContentStatus ContentStatus { get; set; }
        public DateTime PublishDate { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long WriterId { get; set; }
        public Writer Writer { get; set; }


        public List<Comment> Comments { get; set; }
        public List<ContentKeywords> Keyword { get; set; }
        public List<ContentPlaces> PublishPlaces { get; set; }

    }
}
