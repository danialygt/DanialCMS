using DanialCMS.Core.Domain.PublishPlaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Entities
{
    public class ContentPlaces
    {
        public long Id { get; set; }

        public long ContentId { get; set; }
        public Content Content { get; set; }
        public long PublishPlaceId { get; set; }
        public PublishPlace PublishPlace { get; set; }
    }
}
