using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentQueryRepository : IContentQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public ContentQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public Content Get(long id)
        {
            return _cmsDbContext.Contents.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Writer)
                .Include(c => c.Photo)
                .Include(c => c.Category)
                .Include(c => c.Comments)
                .Include(c => c.ContentStatus)
                .Include(c => c.PublishPlaces).ThenInclude(r=>r.PublishPlace)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Content> GetAll()
        {
            return _cmsDbContext.Contents.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Writer)
                .Include(c => c.Photo)
                .Include(c => c.Category)


                .ToList();
        }
    }
}
