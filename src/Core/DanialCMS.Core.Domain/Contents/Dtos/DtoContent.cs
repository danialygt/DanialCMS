using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Editors.Entities;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.Writers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Dtos
{
    public class DtoContent
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public long  PhotoId { get; set; }
        public ContentStatus ContentStatus { get; set; }
        public DateTime PublishDate { get; set; }
        public long WriterId { get; set; }
        public Writer Writer { get; set; }
        public long  CategoryId { get; set; }
        public Category Category { get; set; }


        public List<long> CommentsId { get; set; }
        public List<long> KeywordsId { get; set; }
        public List<long> PublishPlacesId { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Keyword> Keywords { get; set; }
        public List<PublishPlace> PublishPlaces { get; set; }
        public List<Editor> Editors { get; set; }
    }
}
