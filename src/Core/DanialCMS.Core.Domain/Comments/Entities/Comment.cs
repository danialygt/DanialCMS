using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Comments.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public long ContentId { get; set; }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Opinion { get; set; }
        



        public long ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }







    }
}
