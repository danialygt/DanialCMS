using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Comments.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Comments.Repositories
{
    public class CommentCommandRepository : ICommentCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public CommentCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }


        public void CanShow(long commentId, bool show)
        {
            _cmsDbContext.Comments
                .FirstOrDefault(c => c.Id == commentId)
                .CanShow = show;
            _cmsDbContext.SaveChanges();
        }
    }
}
