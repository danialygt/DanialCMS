using DanialCMS.Core.Domain.Editors.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Dtos
{
    public class DtoUpdateContent
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }

        public long PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        public DateTime PublishDate { get; set; }
        public string WriterName { get; set; }
        public long CategoryId { get; set; }


        public List<long> KeywordsId { get; set; }
        public List<long> PublishPlacesId { get; set; }
        public List<Editor> Editors { get; set; }

    }
}
