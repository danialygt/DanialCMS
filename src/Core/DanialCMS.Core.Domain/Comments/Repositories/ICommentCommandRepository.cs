using DanialCMS.Core.Domain.Comments.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Core.Domain.Comments.Repositories
{
    public interface ICommentCommandRepository
    {
        void Add(Comment entity);
    }
}
