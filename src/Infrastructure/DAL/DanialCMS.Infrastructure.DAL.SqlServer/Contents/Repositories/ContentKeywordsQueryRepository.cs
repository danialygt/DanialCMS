using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentKeywordsQueryRepository : IContentKeywordsQueryRepository
    {
        private readonly ContentDbContext _contentDbContext;

        public ContentKeywordsQueryRepository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public ContentKeywords Get(long id)
        {
            return _contentDbContext.ContentKeywords.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

        }

        public List<ContentKeywords> GetAll()
        {
            return _contentDbContext.ContentKeywords.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Content)
                .ToList();
        }

        public List<ContentKeywords> GetContents(long keywordId)
        {
            return _contentDbContext.ContentKeywords.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Content)
                .Where(c => c.KeywordId == keywordId)
                .ToList();
        }

        public List<ContentKeywords> GetKeywords(long contentId)
        {
            return _contentDbContext.ContentKeywords.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Content)
                .Where(c => c.ContentId == contentId)
                .ToList();
        }
    }
}
