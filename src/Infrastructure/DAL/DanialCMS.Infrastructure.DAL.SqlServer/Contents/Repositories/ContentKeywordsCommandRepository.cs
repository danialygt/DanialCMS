using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentKeywordsCommandRepository : IContentKeywordsCommandRepository
    {
        private readonly ContentDbContext _contentDbContext;

        public ContentKeywordsCommandRepository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public void Add(ContentKeywords entity)
        {
            _contentDbContext.ContentKeywords.Add(entity);
            _contentDbContext.SaveChanges();
        }

        public void Delete(ContentKeywords entity)
        {
            _contentDbContext.ContentKeywords.Remove(entity);
            _contentDbContext.SaveChanges();
        }

        public void Edit(ContentKeywords entity)
        {
            _contentDbContext.ContentKeywords.Update(entity);
            _contentDbContext.SaveChanges();
        }

        public void RemoveKeywordsFromContent(long contentId)
        {
            var entities = _contentDbContext.ContentKeywords.AsNoTracking()
                .Where(c => c.ContentId == contentId);

            foreach (var entity in entities)
            {
                _contentDbContext.ContentKeywords.Remove(entity);
            }
                       
            _contentDbContext.SaveChanges();
        }
    }
}
