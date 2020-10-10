using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentCommandRepository : IContentCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public ContentCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public void Add(Content entity)
        {
            _cmsDbContext.Contents.Add(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Content entity)
        {
            _cmsDbContext.Contents.Update(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
