using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentEditorsQueryRpository : IContentEditorsQueryRpository
    {
        private readonly ContentDbContext _contentDbContext;

        public ContentEditorsQueryRpository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public ContentEditors Get(long id)
        {
            return _contentDbContext.ContentEditors.AsNoTracking()
                    .FirstOrDefault(c => c.Id == id);

        }

        public List<ContentEditors> GetAll()
        {
            return _contentDbContext.ContentEditors.AsNoTracking()
                    .Include(c => c.Editor)
                    .Include(c => c.Content)
                    .ToList();
        }

        public List<ContentEditors> GetContents(long editorId)
        {
            return _contentDbContext.ContentEditors.AsNoTracking()
                    .Include(c => c.Editor)
                    .Include(c => c.Content)
                    .Where(c => c.EditorId == editorId)
                    .ToList();
        }

        public List<long> GetEditorsId(long contentId)
        {
            return _contentDbContext.ContentEditors.AsNoTracking()
                    .Where(c => c.ContentId == contentId)
                    .Select(c => c.EditorId)
                    .ToList();
        }
    }
}

