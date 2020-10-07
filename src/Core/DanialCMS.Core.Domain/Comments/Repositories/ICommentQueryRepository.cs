using DanialCMS.Core.Domain.Comments.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Comments.Repositories
{
    public interface ICommentQueryRepository
    {
        Comment Get(long id);
        List<Comment> GetContentComments(long contentId);
        List<Comment> GetAll();
    }
}
