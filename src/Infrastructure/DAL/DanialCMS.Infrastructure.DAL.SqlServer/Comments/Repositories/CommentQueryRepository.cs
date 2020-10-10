using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Comments.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Comments.Repositories
{
    public class CommentQueryRepository : ICommentQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public CommentQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public Comment Get(long id)
        {
            return _cmsDbContext.Comments.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetAll()
        {
            return _cmsDbContext.Comments.AsNoTracking()
                .ToList();
        }

        public List<Comment> GetContentComments(long contentId)
        {
            return _cmsDbContext.Comments.AsNoTracking()
                .Where(c => c.ContentId == contentId)
                .ToList();
        }
    }
}
