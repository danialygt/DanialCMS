using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Comments.Repositories;
using System;
using System.Collections.Generic;
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

        public void Add(Comment entity)
        {
            _cmsDbContext.Comments.Add(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
