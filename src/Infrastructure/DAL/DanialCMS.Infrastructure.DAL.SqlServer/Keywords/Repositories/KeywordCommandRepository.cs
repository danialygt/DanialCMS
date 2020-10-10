using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Keywords.Repositories
{
    public class KeywordCommandRepository : IKeywordCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public KeywordCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public void Add(Keyword entity)
        {
            _cmsDbContext.Keywords.Add(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Delete(Keyword entity)
        {
            _cmsDbContext.Keywords.Remove(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Keyword entity)
        {
            _cmsDbContext.Keywords.Update(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
