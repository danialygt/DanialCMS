using DanialCMS.Core.Domain.Contents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Comments.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public long ContentId { get; set; }
        public Content Content { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Opinion { get; set; }
        



        public long? ParentId { get; set; }
        public Comment Parent { get; set; }
        public List<Comment> Children { get; set; }







    }
}
