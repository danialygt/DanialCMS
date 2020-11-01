using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentEditorsCommandRpository : IContentEditorsCommandRpository
    {
        private readonly ContentDbContext _contentDbContext;

        public ContentEditorsCommandRpository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public void Add(ContentEditors entity)
        {
            _contentDbContext.ContentEditors.Add(entity);
            _contentDbContext.SaveChanges();
        }

        public void Delete(ContentEditors entity)
        {
            var ent = _contentDbContext.ContentEditors
                .FirstOrDefault(d => d.Id == entity.Id);
            _contentDbContext.ContentEditors.Remove(ent);
            _contentDbContext.SaveChanges();
        }

        public void Edit(ContentEditors entity)
        {
            _contentDbContext.ContentEditors.Update(entity);
            _contentDbContext.SaveChanges();
        }

        public void RemoveEditorsFromContent(long contentId)
        {
            var entities = _contentDbContext.ContentEditors.AsNoTracking()
                .Where(c => c.ContentId == contentId);

            foreach (var entity in entities)
            {
                _contentDbContext.ContentEditors.Remove(entity);
            }

            _contentDbContext.SaveChanges();
        }
    }
}
