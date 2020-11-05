using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.FileManagements.Dtos;
using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Commands
{
    public class AddContentCommand:ICommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public long? PhotoId { get; set; }
        public ContentStatus ContentStatus { get; set; } = ContentStatus.Waiting;
        public DateTime PublishDate { get; set; }

        public long  CategoryId { get; set; }
        public List<long> KeywordsId { get; set; }
        public List<long> PublishPlacesId { get; set; }
        
        public long WriterId { get; set; }


    }
}
