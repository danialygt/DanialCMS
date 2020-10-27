using DanialCMS.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Comments.Commands
{
    public class ChangeStatusCommentCommand : ICommand
    {
        public long CommentId { get; set; }
        public bool CommentStatus { get; set; }

    }
}
