using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Dtos
{
    public class DtoListContent
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string WriterName { get; set; }
        public ContentStatus ContentStatus { get; set; }
        public DateTime PublishDate { get; set; }

        public List<PublishPlace> PublishPlaces { get; set; }

    }
}
