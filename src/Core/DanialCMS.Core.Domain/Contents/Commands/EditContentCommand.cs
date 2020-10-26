using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Contents.Commands
{
    public class EditContentCommand : ICommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public long PhotoId { get; set; }
        public DateTime PublishDate { get; set; }

        public long CategoryId { get; set; }
        public List<long> KeywordsId { get; set; }
        public List<long> publishPlacesId { get; set; }
    }
}
